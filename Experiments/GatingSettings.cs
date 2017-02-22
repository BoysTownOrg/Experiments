using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Experiments
{
    class GatingSettings
    {
       
        // Serializes the class to the config file
        // if any of the settings have changed.
        public bool SaveAppSettings()
        {
           StreamWriter myWriter = null;
           XmlSerializer mySerializer = null;
            try
            {   // Create an XmlSerializer for the 
                // ApplicationSettings type.
                mySerializer = new XmlSerializer(
                    typeof(GatingSettings));
                myWriter =
                    new StreamWriter(Application.LocalUserAppDataPath
                    + @"\\GatingSetting.config", false);
                // Serialize this instance of the ApplicationSettings 
                // class to the config file.
                mySerializer.Serialize(myWriter, this);
            }
            catch (Exception )
            {
                return false;
            }
            finally
            {
                // If the FileStream is open, close it.
                if (myWriter != null)
                {
                    myWriter.Close();
                }

            }
            return true;
        }

    }
}
