using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using Microsoft.DirectX.DirectDraw;


namespace FeedbackVisual
{
    /// <summary>
    /// Summary description for GameType.
    /// </summary>
    public enum GameType { None, DotToDot, Zap, Reveal, Slideshow };

    /// <summary>
    /// Summary description for Game.
    /// </summary>
    public class Game : object
    {
        private Device draw = null; // Holds the DrawDevice object.
        private SurfaceDescription description;
        private SurfaceDescription description2;
        private Surface primary = null; // Holds the primary destination surface.
        private Surface offscreen = null; // Holds the offscreen surface that the bitmap will be loaded on.
        private Clipper clip = null; // Holds the clipper object.
        private Rectangle destination = new Rectangle();
        private Font font = null;//screen text font;
        private Panel panel;
        public GameType Type;
        private Size size;
        private string strCurrentPic;
        private string strEndPic;
        private ArrayList lstPts;
        private ArrayList MasterList;
        private int nCount;
        private Point lastOrigin;
        private Color c = Color.Black;

        public Color BackgroundColor;
        public Color ForeColor;
        public Game()
        {
            panel = null;
            BackgroundColor = Color.Black;
            ForeColor = Color.Red;
            Type = 0;
            
            strCurrentPic = string.Empty;
            Type = GameType.None;
            strEndPic = string.Empty;
            lstPts = new ArrayList();
            nCount = 0;

        }
        public int Max() { return lstPts.Count; }

        private void SetDescriptions()
        {
            description = new SurfaceDescription(); // Create a new SurfaceDescription struct.
            description.SurfaceCaps.PrimarySurface = true; // The caps for this surface is simply primary.
            description2 = new SurfaceDescription();
            description2.SurfaceCaps.OffScreenPlain = true;
            description2.Height = panel.Height;
            description2.Width = panel.Width;
        }
        private void CreateSurfaces()
        {
            if (primary != null)
                primary.Dispose();
            primary = new Surface(description, draw); // Create the primary surface.
            clip = new Clipper(draw); // Create a new clipper.
            clip.Window = panel; // The clipper will use the main window handle.
            primary.Clipper = clip; // Assign this clipper to the primary surface.

            if (strCurrentPic.Length > 0)
            {
                offscreen = new Surface(strCurrentPic, description2, draw); // Create the surface using the specified file.
            }
            else
                offscreen = new Surface(description2, draw); // Create surface.
        }

       public void ShowOffscreen()
        {
            if (offscreen != null) primary.Draw(destination, offscreen, DrawFlags.Wait);
        } 
        public void FadeScreen()
        {
            try
            {
                Surface tempSurface = new Surface(description2, draw);
                tempSurface.FillColor = Color.DimGray;
                tempSurface.DrawBox(0, 0, size.Width, size.Height);
                primary.Draw(destination, tempSurface, DrawFlags.Wait);
                tempSurface.Dispose();
            }
            catch (Exception) { }
        }
        public void Draw(Point p)
        {
            lastOrigin = p;
            Draw(0);
        }
        public void Draw(int nType)
        {
            try
            {
                if (null == primary)
                    return;
                // Get the new client size to Draw to.
                destination = new Rectangle(lastOrigin, size);
                if (description != null)
                {
                    offscreen.ForeColor = Color.Black;
                    offscreen.FillColor = Color.White;
                    IntPtr ptr;
                    ptr = font.ToHfont();
                    offscreen.FontHandle = ptr;
                    offscreen.DrawWidth = 5;

                    int x = size.Width;
                    int y = size.Height;
                    int n = 0;
                    //draw points
                    if (Type == GameType.Slideshow)
                    {
                        FileInfo f = new FileInfo(strCurrentPic);
                        if (f.Exists == false)
                        {
                            MessageBox.Show("Unable to find picture: " + strCurrentPic);
                            return;
                        }
                        offscreen = new Surface(strCurrentPic, description2, draw);
                    }
                    else if (Type == GameType.Reveal)
                    {
                        offscreen.Dispose();
                        offscreen = new Surface(strCurrentPic, description2, draw);
                        offscreen.ForeColor = Color.White;
                        offscreen.FillColor = Color.White;
                        foreach (PicPt a in lstPts)
                        {
                            int X = (int)(x * a.x);
                            int Y = (int)(y * a.y);
                            int W = (int)(x * (a.x + 0.2));
                            int H = (int)(y * (a.y + 0.2));
                            offscreen.DrawBox(X, Y, W, H);
                        }
                    }
                    else
                    {
                        if (Type == GameType.Zap)
                            offscreen.ForeColor = c;
                        foreach (PicPt p in lstPts)
                        {
                            n++;
                            if (n == 1 && Type == GameType.Zap)
                                continue;
                            else if (Type == GameType.Zap)
                                offscreen.DrawText((int)(x * p.x), (int)(y * p.y), "*", false);
                            if (Type == GameType.DotToDot)
                                offscreen.DrawText((int)(x * p.x), (int)(y * p.y), "*" + n.ToString(), false);
                        }

                        offscreen.ForeColor = Color.Red;
                        //draw line
                        if (lstPts.Count > 0)
                        {
                            if (Type == GameType.DotToDot)
                            {
                                for (int i = 0; i < nCount; i++)
                                {
                                    PicPt a, b;
                                    a = (PicPt)lstPts[i];
                                    b = (PicPt)lstPts[i + 1];
                                    offscreen.DrawLine((int)(x * a.x), (int)(y * a.y), (int)(x * b.x), (int)(y * b.y));
                                }
                            }

                            if (nType == 1)//drawing a zap line
                            {
                                PicPt a, b;
                                a = (PicPt)lstPts[0];
                                b = (PicPt)lstPts[1];
                                //offscreen.DrawLine((int)(x*a.x),(int)(y*a.y),(int)(x*b.x),(int)(y*b.y+5));
                                offscreen.DrawLine((int)(x * b.x), (int)(y * b.y + 5), (int)(x * a.x), (int)(y * a.y));
                            }
                        }
                    }
                }
                // Try and Draw the offscreen surface on to the primary surface.
                primary.Draw(destination, offscreen, DrawFlags.Wait);

            }
            catch (Exception)
            {
                CreateSurfaces();
            }

        }
        public void SetPanel(System.Windows.Forms.Panel panelDraw)
        {
            panel = panelDraw;
            draw = new Microsoft.DirectX.DirectDraw.Device(); // Create a new DrawDevice, using the default device.
            draw.SetCooperativeLevel(panel, CooperativeLevelFlags.Normal); // Set the coop level to normal windowed mode.
            SetDescriptions();
            CreateSurfaces();

        }
        public void SetSize(Size s)
        {
            size = s;
        }
        public void LoadGame(string strFile, bool bRandomizeFeedback)
        {
            LoadGame(strFile);
            if (bRandomizeFeedback)
            {
                Random r = new Random(DateTime.Now.Millisecond);
                ArrayList temp = (ArrayList)lstPts.Clone();
                int rand;
                lstPts.Clear();
                while (temp.Count > 0)
                {
                    rand = r.Next(temp.Count);
                    lstPts.Add((string)temp[rand]);
                    temp.RemoveAt(rand);
                }
            }
        }
        private void LoadGame(string strFile)
        {
            string strType,strLine;
            string []FeedbackFile = File.ReadAllLines(strFile);
            int iCounter = 0,ncount;

            //ignore blank spaces on top
            while (FeedbackFile[iCounter].Trim().Equals(string.Empty)) iCounter++;
            
            //obtain game type
            strType = GameParse(FeedbackFile[iCounter++]);
            strType = strType.ToUpper();
            if (strType == "DOT_TO_DOT")
                Type = GameType.DotToDot;
            else if (strType == "REVEAL")
                Type = GameType.Reveal;
            else if (strType == "SLIDESHOW")
                Type = GameType.Slideshow;

            //ignore blank after 'Game Type' line
            while (FeedbackFile[iCounter].Trim().Equals(string.Empty)) iCounter++;

            //obtain first pic to display
            strCurrentPic = GameParse(FeedbackFile[iCounter++]);
            nCount = 0;

            switch (Type)
            {
                case GameType.Reveal: 
                    InitReveal();
                    ncount = lstPts.Count;
                    break;

                case GameType.DotToDot: 
                    strEndPic = GameParse(FeedbackFile[iCounter++]);
                    //read points
                    strLine = FeedbackFile[iCounter++];
                    while (iCounter < FeedbackFile.Length)
                    {
                        AddPoints(strLine);
                        strLine = FeedbackFile[iCounter++];
                    }
                    break;

                case GameType.Slideshow:

                    string[] sfiles = Directory.GetFiles(strCurrentPic);
                    strCurrentPic = sfiles[0];
                    foreach (string s in sfiles)
                    {
                        AddPic(s);
                    }
    			    nCount = 0;
                    break;
    			

            }
            font = new Font("Arial", 7);
            offscreen = new Surface(strCurrentPic, description2, draw);
            MasterList = (ArrayList)lstPts.Clone();
            Draw(0);
        }

        private void AddPic(string str)
        {
            str = str.Trim();
            if (str.IndexOf("%") == 0)
                return;
            int n = str.IndexOf(';');
            if (n > 0)
                str = str.Substring(0, n);
            str = str.Trim();
            if (str.Length > 0)
                lstPts.Add(str);
        }
        private string GameParse(string str)
        {
            int n;
            n = str.IndexOf(';');
            if (n > 0)
                str = str.Substring(0, n);
            str = str.Replace(';', ' ');
            str = str.Trim();
            return str;
        }

        private void InitReveal()
        {
            double x = 0.0;
            double y = 0.0;
            for (int i = 0; i < 5; i++)
            {
                x = 0.0;
                for (int j = 0; j < 5; j++)
                {
                    lstPts.Add(new PicPt(x, y));
                    x += 0.2;
                }
                y += 0.2;
            }
        }
        private void AddPoints(string str)
        {
            str = str.Trim();
            if (str.IndexOf("%") == 0)
                return;
            int n = str.IndexOf(';');
            if (n > 0)
                str = str.Substring(0, n);
            n = str.IndexOf(' ');
            if (n < 0)
                return;
            string str1, str2;
            str1 = str.Substring(0, n);
            str2 = str.Substring(n + 1);
            lstPts.Add(new PicPt(double.Parse(str1.Trim()), 1 - double.Parse(str2.Trim())));
        }
        
        public bool StepGame(Point p)
        {
            lastOrigin = p;
            if (Type == GameType.Slideshow)
            {
                nCount++;
                if (nCount >= lstPts.Count - 1)
                    return false;
                strCurrentPic = (string)lstPts[nCount];
                this.Draw(0);
                return true;
            }
            
            else if ((Type != GameType.Reveal && nCount < Max() - 1) ||
                (Type == GameType.Reveal && lstPts.Count > 0))
            {
                if (Type == GameType.DotToDot)
                {
                    nCount++;
                    this.Draw(0);
                }
                else if (Type == GameType.Zap)
                {
                    //Show Red Line
                    this.Draw(1);
                }
                else if (Type == GameType.Reveal)
                {
                    Random r = new Random(DateTime.Now.Millisecond);
                    int x = r.Next(lstPts.Count - 1);
                    PicPt pic = (PicPt)lstPts[x];
                    lstPts.RemoveAt(x);

                    int Count = 0;
                    PicPt a = null;
                    PicPt b = null;

                    for (int i = 0; i < lstPts.Count; i++)
                    {
                        PicPt pt = (PicPt)lstPts[i];
                        if (a == null)
                        {
                            if (pt.y == pic.y)
                            {
                                if (pt.x == pic.x + 0.1)//one to the right
                                {
                                    if (r.Next(2) == 1)
                                        continue;
                                    Count++;
                                    a = pt;
                                }
                                else if (pt.x == pic.x - 0.1)//one to the left
                                {
                                    Count++;
                                    a = pt;
                                }
                            }
                        }
                        if (b == null)
                        {
                            if (pt.x == pic.x)
                            {
                                if (pt.y == pic.y + 0.1)//one to the right
                                {
                                    if (r.Next(2) == 1)
                                        continue;
                                    Count++;
                                    b = pt;
                                }
                                else if (pt.y == pic.y - 0.1)//one to the right
                                {
                                    Count++;
                                    b = pt;
                                }
                            }
                        }
                    }//for
                    if (a != null)
                    {
                        lstPts.Remove(a);
                    }
                    if (b != null)
                    {
                        lstPts.Remove(b);
                    }
                    this.Draw(0);
                }
            }
            if (Type != GameType.Reveal)
            {
                if (nCount >= Max() - 1)
                {
                    //Get next Game
                    if (Type == GameType.DotToDot)
                        ShowDotPic();
                    return false;
                }
            }
            else
            {
                if (lstPts.Count == 0)
                {
                    this.Draw(0);
                    return false;
                }
            }
            return true;
        }
        public void Reset()
        {
            nCount = 0;
            lstPts = (ArrayList)MasterList.Clone();
            strCurrentPic = (string)lstPts[nCount];
            this.Draw(0);
        }

        private void ShowDotPic()
        {
            //Show Full Pic
            description.Clear(); // Clear the SurfaceDescription struct.
            offscreen = new Surface(strEndPic, description, draw);
            lstPts.Clear();
            this.Draw(2);
            //Wait
            System.DateTime dt = System.DateTime.Now;
            System.DateTime d2;
            do
            {
                d2 = System.DateTime.Now;
            } while (d2.Minute == dt.Minute && d2.Second - dt.Second < 2);
            //wait 1-2 seconds
            //go to next game
            //this.Draw(2);*/

        }
        public int GetPoints()
        {
            return MasterList.Count;
        }
    
    }
    /// <summary>
    /// Summary description for PicPt.
    /// </summary>
    public class PicPt : object
    {
        public double x;
        public double y;
        public bool bDraw;
        public PicPt(double a, double b)
        {
            x = a;
            y = b;
            bDraw = true;

        }

    }

   
	
}
