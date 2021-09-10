using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Xml;

namespace BlinkSyncLib
{
    public abstract class XmlReader
    {

        #region Fields

        #endregion

        #region Properties
        protected string ConfigFilePath { get; set; } =
         @"..\XML\SampleXML\UtilConfigurationXMLSample1.xml";

        protected XDocument ConfigFile { get; set; }

        protected string NODE_MAIL_SERVER { get; set; } = "mail-server";
        protected string NODE_MAIL_RECIPIENTS { get; set; } = "email-recipients";
        protected string NODE_EMAIL_ADDRESS { get; set; } = "email";

        #endregion

        #region Events / Delegates
        #endregion

        #region Constructor

        public XmlReader() {  }

        public XmlReader(bool loadDefaultConfigFile)
        {
            if (loadDefaultConfigFile)
            {
                ConfigFile = XDocument.Load(ConfigFilePath);
            }
        }

        public XmlReader(string path)
        {
            ConfigFilePath = path;
            ConfigFile = XDocument.Load(ConfigFilePath);
        }
        #endregion


        #region Methods

        public virtual List<string> GetEmailRecipients()
        {
            try
            {
                var recipients = ConfigFile.Descendants(NODE_MAIL_RECIPIENTS).FirstOrDefault();

                if (recipients == null) { return new List<string>(); }

                return recipients.Descendants(NODE_EMAIL_ADDRESS)
                                 .Select(element => element.Value)
                                 .ToList();
            }
            catch { return new List<string>(); }
        }


        public virtual string GetMailServer()
        {
            try
            {
                var data = ConfigFile.Descendants(NODE_MAIL_SERVER).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }
        #endregion

    }

}
