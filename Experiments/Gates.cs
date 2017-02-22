using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Audio;
using System.ComponentModel;
using System.Windows.Forms;
using Experiments.Properties;

namespace Experiments
{
    /*
     * This class encapsulates One complete Gate experiment.Experiment consists of
     * playing a set of sound files and recording subject response parameters
     */

    public class GateUnit
    {
        bool newTest = false;
        
        List<Word> TestWords=new List<Word>(); //list of words selected for test
        List<Word> AllWords = new List<Word>(); //list of all words in folder
        BindingList<Summary> summary = new BindingList<Summary>();
        int iCurrentWord;
        int iCurrentGate=0;
        Word wCurWord;
        Gate gCurGate;
        public int Level { get; set; }
        public string CurrentFileToPlay=string.Empty;
        public string strDirPath { get; set; }
        public string[] feedbackfiles { get; set; }
        SoundCard sc = new SoundCard();
        Generator.Ears ear;
        List<string> _filesToCopyAfterBreak;
       // List<string> FilesToCopyAfterBreak;
        /// <summary>
        /// Sort stim files by name and create list
        /// </summary>
        /// <param name="allFiles"></param>
        public void SetupGame(string []allFiles)
        {
           
            FillWordsList(allFiles);
            sc.OpenSoundCard();
        }
        //fills Words list for this class.
        private void FillWordsList(string []allFiles)
        {
            FileInfo fi = new FileInfo(allFiles[0]);
            strDirPath = fi.DirectoryName;
            string[] seperator = new string[] { "_", ".","-" };
            Word w=null;
            AllWords.Clear();

          
            if (allFiles[0].Contains("RLW"))
            {
                foreach (string s in allFiles)
                {
                    string strFileName = s.Remove(0, strDirPath.Length + 1);//+2 accounts for \\ at the end
                    //eg: 06_RLW_L_gladbillcalled_peak_50.wav
                    string[] t1_str = strFileName.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                    string predictind, keyword = "";
                    Nullable<int> iMs;
                    iMs = int.Parse(t1_str[5]);
                    keyword = t1_str[4];
                    predictind = t1_str[2];
                    w = WordExists(keyword, predictind, AllWords);

                    if (null == w)//!WordExists(t1_str[4],t1_str[2],AllWords))
                    {
                        w = new Word();
                        w.Predictability = predictind;
                        w.sWord = keyword;
                        w.Add(iMs, strFileName);
                        w.DirPath = strDirPath;
                        AllWords.Add(w);
                    }
                    else
                    {
                        // w = AllWords.Find(delegate(Word x) { return x.sWord.Equals(t1_str[4], StringComparison.InvariantCultureIgnoreCase)
                        //                                        && x.Predictability.StartsWith(t1_str[2],StringComparison.InvariantCultureIgnoreCase); });
                        w.Add(iMs, strFileName);
                    }

                }

            }
            else 
            {
               
                   foreach (string s in allFiles)
                   {
                       string strFileName = s.Remove(0, strDirPath.Length + 1);//+2 accounts for \\ at the end
                       //eg: 06_RLW_L_gladbillcalled_peak_50.wav
                       string[] t1_str = strFileName.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                       string predictind, keyword = "";
                       Nullable<int> iMs;
                       try
                       {
                           int durationnumber;
                           durationnumber = int.Parse(t1_str[2]);
                           if (durationnumber == 1)
                           {
                                   iMs = new Settings().BaseGate;
                           }
                           else
                           {
                                    iMs = 150 + (durationnumber -1) * new Settings().GateSteps;
                           
                            }
                       }
                       catch (Exception)
                       {
                           iMs = 10000;
                       }
                       keyword = t1_str[0];
                       predictind = t1_str[1].Substring(0, 1);
                       newTest = true;
                       w = WordExists(keyword, predictind, AllWords);
                       if (null == w)//!WordExists(t1_str[4],t1_str[2],AllWords))
                       {
                           w = new Word();
                           w.Predictability = predictind;
                           w.sWord = keyword;
                           w.Add(iMs, strFileName);
                           w.DirPath = strDirPath;
                           AllWords.Add(w);
                       }
                       else
                       {
                           // w = AllWords.Find(delegate(Word x) 
                           //{ return x.sWord.Equals(t1_str[4], StringComparison.InvariantCultureIgnoreCase)
                           // && x.Predictability.StartsWith(t1_str[2],StringComparison.InvariantCultureIgnoreCase); });
                           w.Add(iMs, strFileName);
                       }

                  }

                   List<Word> Test = SortAndArrangeByPredictibilityByWord(AllWords);
                   AllWords = ReAssembleList(Test);

               
             }
            Sort(AllWords);
            TestWords = AllWords;
        }

        private List<Word> ReAssembleList(List<Word> Test)
        {
            List<Word> BeforeBreak= Test.Where((x, i) => i % 2 == 0).ToList<Word>();
            List<Word> AfterBreak = Test.Where((x, i) => i % 2 != 0).Reverse().ToList<Word>() ;


            ArrangeInHighLow(BeforeBreak);

            ArrangeInHighLow(AfterBreak);


            PopulateFilesToCopy(AfterBreak);
           

            return BeforeBreak.Union(AfterBreak).ToList<Word>();
            
        }
        private void ArrangeInHighLow(List<Word> words)
        {
           
            string predictabilityOfFirstWord = words[0].Predictability;
            List<Word> firstPredictibility = words.Where(x => x.Predictability == predictabilityOfFirstWord).ToList();
            List<Word> LastPredictibility = words.Where(x=>x.Predictability != predictabilityOfFirstWord).ToList();
            List<Word> BeginningList = new List<Word>();
            List<Word> EndingList = new List<Word>();
            BeginningList.AddRange(firstPredictibility);
            EndingList.AddRange(LastPredictibility);   
       

            if (firstPredictibility.Count < LastPredictibility.Count)
            {
                BeginningList.Clear();
                EndingList.Clear();
                
                BeginningList.AddRange(LastPredictibility);
                EndingList.AddRange(firstPredictibility);
            }


            for (int x= 0,y = 0; y < BeginningList.Count; x+=2,y++)
            {
                words[x] = BeginningList[y];
                if(EndingList.Count > y)
                {
                    words[x + 1] = EndingList[y];
                }
            }
            
           

        }

        private void PopulateFilesToCopy(List<Word> FilesToCopy)
        {
             _filesToCopyAfterBreak = new List<string>();
            foreach (Word item in FilesToCopy)
            {
                foreach(Gate g in item.Gates)
                {
                    _filesToCopyAfterBreak.Add(item.DirPath + "\\" + g.Stimuli);
                }
                
            }


        }

        public List<string> FilesToCopyAfterBreak
        {
            get { return _filesToCopyAfterBreak; }
            
        }

        private void Shuffle( List<Word> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Word value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private List<Word> SortAndArrangeByPredictibilityByWord(List<Word> AllWords)
        {
         List<Word> SortedByPredictibility = SortByPredictibility(AllWords);

         List<Word> RearrangedHighList = SortedByPredictibility.Where(G => G.Predictability == "HIGH").OrderBy(G => G.sWord).ToList<Word>();
         List<Word> ReArrangedLowList ;
         if (RearrangedHighList.Count % 2 == 0)
         {
            ReArrangedLowList = SortedByPredictibility.Where(G => G.Predictability == "LOW").OrderByDescending(G => G.sWord).ToList<Word>();
         }
         else
         {
            ReArrangedLowList = SortedByPredictibility.Where(G => G.Predictability == "LOW").OrderBy(G => G.sWord).ToList<Word>();
 
         }
         Shuffle(RearrangedHighList);
         Shuffle(ReArrangedLowList);

         return RearrangedHighList.Union(ReArrangedLowList).ToList<Word>();

        }


        private List<Word> SortByPredictibility(List<Word> AllWords)
        {
            var v = (from G in AllWords
                     orderby G.Predictability ascending, G.sWord ascending
                     select G);
            return  v.ToList<Word>();

            
        }
        /// <summary>
        /// Checks if <c>testWord</c> of predictability <c>testPredic</c> is already in list <c>W</c>
        /// </summary>
        /// <param name="testWord"></param>
        /// <param name="testPredic"></param>
        /// <param name="w"></param>
        /// <returns>Word from W with matching criteria. Null if no match</returns>
        private  Word WordExists(string testWord,string testPredic,List<Word> w)
        {
            return (w.Find(delegate(Word x)
            {
              return  x.sWord.Equals(testWord, StringComparison.InvariantCultureIgnoreCase)&&
                      x.Predictability.StartsWith(testPredic,StringComparison.InvariantCultureIgnoreCase);
            })) ;
            
        }

        public bool Play()
        {
            //if Last play hasn't been scored, dont play more than once
            if (string.IsNullOrEmpty(CurrentFileToPlay)) 
                return false;
            if (newTest)
            {
               
            string left = string.Format("{0}L.wav",CurrentFileToPlay.Substring(0,CurrentFileToPlay.Length -5));
            string right = string.Format("{0}R.wav", CurrentFileToPlay.Substring(0, CurrentFileToPlay.Length - 5));

                
            StereoPlayTwoFiles(left, right);
            CurrentFileToPlay = string.Empty;
            iCurrentGate = iCurrentGate + 2;
               
            }
            else
            {
             Play(CurrentFileToPlay, Generator.Ears.Both);
             CurrentFileToPlay = string.Empty;
             iCurrentGate++;
            }
            return true;
           
        }

        private void StereoPlayTwoFiles(string left, string right)
        {
            bool leftsuccess = false;
            bool rightsuccess = false;
            MemoryStream msLeft, msRight;
            MemoryStream msBoth = new MemoryStream();
          
            Generator.SetEars(Generator.Ears.Left);
            leftsuccess =  Generator.WaveFile(left, out msLeft);
            
            Generator.SetEars(Generator.Ears.Right);
            rightsuccess = Generator.WaveFile(right, out msRight);

            
            
            Generator.SetEars(Generator.Ears.Both);
            if (leftsuccess && rightsuccess)
            {

                msBoth.Write(msLeft.GetBuffer(), 0, Convert.ToInt32(msLeft.Length / 2));
                msBoth.Write(msRight.GetBuffer(), Convert.ToInt32(msLeft.Length / 2), Convert.ToInt32(msRight.Length / 2));
                int[] nSize = new int[2];
                nSize[0] = (int)(msBoth.Length / 2) / 4;
                nSize[1] = 0;
                if (sc.Open)
                {
                    sc.PlayMemoryStream(msBoth, nSize, 1);
                }
            }
        }
       
        
        //give me a full path for file, i will play it for you
        private void  Play(string soundfile,Generator.Ears ears)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                Generator.SetEars(ears);
                bool b = Generator.WaveFile(soundfile, out ms);
                int BigInt = (int)(ARSC.SCALE_32BIT * (Math.Pow(10, Level / 20.0)));
                ms = Generator.SetRmsLevel(ms, BigInt);
                if (b)//read successful
                {
                    int[] nSize = new int[2];
                    nSize[0] = (int)(ms.Length / 2) / 4;
                    nSize[1] = 0;
                    if (sc.Open) sc.PlayMemoryStream(ms, nSize, 1);
                }
            }
            catch (Exception )
            {
                return;
            }
            finally
            {
                ms.Close();
            }
        }

    

        public bool Step(ref BindingList<GateReporter> reports,bool previousresult)
        {
            bool newWord = false;
            //is CurrentFileToPlay hasn't been played, dont step through
            if (! string.IsNullOrEmpty(CurrentFileToPlay)) 
            {
                newWord = false;
                return newWord;
            }

             //if previous play was correct, move to next word
            if (previousresult)
            {
                MoveNext(previousresult);
                newWord = true;
            }
            if (iCurrentWord >= TestWords.Count)
            {
                sc.CloseSoundCard();
                newWord = false;
                return newWord;
            }
           
            //if all gates used up,move to next word
            if (iCurrentGate >= TestWords[iCurrentWord].GateCount)
            {
                MoveNext(previousresult);
                newWord = true;
            }
            //if all words used up, return
            if (iCurrentWord >= TestWords.Count)
            {
                sc.CloseSoundCard();
                newWord = false;
                return newWord;
            }
            wCurWord = TestWords[iCurrentWord];
            gCurGate = wCurWord.GateAt(iCurrentGate);
           
            CurrentFileToPlay = wCurWord.PathOfStimAt(iCurrentGate);
           
           
            GateReporter rep = new GateReporter();
            rep.RootWord = wCurWord.sWord;
            rep.Filename = gCurGate.Stimuli;
            rep.GatesPresented = gCurGate.Duration;
            rep.Predictability = wCurWord.Predictability;
            rep.Sequence = iCurrentGate+1;//1 based sequence number
           
            reports.Add(rep);
            return newWord;
        }
        private void MoveNext(bool previousresult)
        {
            summary.Add(new Summary(wCurWord.sWord,wCurWord.Predictability,iCurrentGate,previousresult?"Correct":"Incorrect"));
            iCurrentWord++;
            iCurrentGate = 0;
        }
        /// <summary>
        /// Calls SortGates for each word in lstwords. Sorts gates according to their length in ms.
        /// </summary>
        /// <param name="lstWords"></param>
        private void Sort(List<Word> lstWords)
        {
            foreach (Word w in lstWords)
                w.SortGates();
        }
        public int CurrentWordIndex { get { return iCurrentWord; } }
        public int CurrentGateIndex { get { return iCurrentGate; } }
       
        public int NumOfWords { get { return TestWords.Count(); } }
        public int GetTotalStim()
        {
            int i = 0;
            foreach (Word w in TestWords)
            {
                i += w.GateCount;
            }
            return i;
        }
        public BindingList<Summary> WordSummary { get { return summary; } }
    }

    /*
     * GateWord is one stim category that includes all gates for that stim
     */ 
    class Word
    {
        private string _predictability; //HIGH, LOW
        private string _word;           //word associated with this sentence
        public List<Gate> Gates = new List<Gate>();        //Gates associated with this word
        public string Predictability
        {
            get
            {
                if (_predictability == "H" || _predictability == "HP") return "HIGH";
                else if (_predictability == "L"|| _predictability == "LP") return "LOW";
                else return "NA";
            }
            set { _predictability = value.ToUpper();}
        }
        public string sWord
        {
            get { return _word; }
            set { _word = value; }
        }
        public string DirPath {get; set;}
        public void Add(int ? ms,string sGates)
        {
            Gates.Add(new Gate(ms,sGates));
        }
        public void Add(int? ms, string sGates, Generator.Ears ears)
        {
            Gates.Add(new Gate(ms, sGates,ears));
        }
        public void SortGates()
       {        
            var v = (from G in Gates orderby G.Duration ascending select G );
            Gates = v.ToList<Gate>();
        }
        public string PathOfStimAt(int i)
        {
            if (i >= Gates.Count) return "";
            return this.DirPath+"\\"+Gates[i].Stimuli;
        }
        public Gate GateAt(int i)
        {
            return Gates[i];
        }
        public int GateCount { get { return Gates.Count; } }           
    }
    class Gate
    {
        Nullable<int> miliseconds;
        private string _filename;
        public Generator.Ears _ear;
        public string Score { get; set; }
        public Gate(int ms, string sGates)
        {
            miliseconds = ms;
            _filename = sGates;
        }
        public Gate(int ms, string sGates,Generator.Ears ears)
        {
            miliseconds = ms;
            _filename = sGates;
            _ear = ears;
        }
        public Gate(int ? ms, string sGates)
        {
            miliseconds = ms;
            _filename = sGates;
        }
        public Gate(int? ms, string sGates,Generator.Ears ears)
        {
            miliseconds = ms;
            _filename = sGates;
            _ear = ears;
        }
        public Nullable<int> Duration
       {
           get { return miliseconds;} 
       }
        public string Stimuli
        {
           get { 
                return    _filename; 
           }
        }

     }
    public class Summary
    {
        public string RootWord { get; set; }
        public string Predictability { get; set; }
        public int GatesUsed { get; set; }
        public string FinalGate { get; set; }
        public Summary(string rword, string pred, int gatenum, string final)
        {
            RootWord = rword;
            Predictability = pred;
            GatesUsed = gatenum;
            FinalGate = final;
        }
    }
}
