using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlinkSyncLib
{
    public class BlinkSyncConfig : XmlReader
    {
        #region Types
        #endregion

        #region Fields
        protected string NODE_TEMPLATE_FILES_SOURCE_DIRECTORY = "template-files-source-directory";
        protected string NODE_TEMPLATE_FILES_DESTINATION_DIRECTORY = "template-files-destination-directory";

        protected string NODE_PULL_CALBAR_FILES_ORIGIN = "pull-origin";
        protected string NODE_PULL_CALBAR_FILES_DESTINATION = "pull-destination";
        protected string NODE_PULL_CALBAR_FILES_ERROR_DESTINATION = "pull-error-destination";
        protected string NODE_PULL_CALBAR_TEMP_DIRECTORY = "pull-temp-directory";
        protected string NODE_PUSH_CALBAR_FILES_ORIGIN = "push-origin";
        protected string NODE_PUSH_CALBAR_FILES_DESTINATION = "push-destination";
        protected string NODE_PUSH_CALBAR_FILES_ERROR_DESTINATION = "push-error-destination";
        protected string NODE_PUSH_CALBAR_TEMP_DIRECTORY = "push-temp-directory";

        //test data transfer daemon liv and sql inserts
        protected string NODE_PULL_CALBAR_UPLOAD_LIV_ORIGIN = "pull-upload-liv-directory";
        protected string NODE_PULL_CALBAR_UPLOAD_SQLINSERTS_ORIGIN = "pull-upload-sqlinserts-directory";

        protected string NODE_CALBAR_SFTP_NODE = "sftp-connection";
        protected string NODE_CALBAR_SFTP_SERVER = "server";
        protected string NODE_CALBAR_SFTP_USER = "username";
        protected string NODE_CALBAR_SFTP_PASSWORD = "password";

        protected string NODE_DB_SERVER1 = "database1-connection";
        protected string NODE_DB_SERVER1_SERVERNAME = "server";
        protected string NODE_DB_SERVER1_DATABASE = "database-name";
        protected string NODE_DB_SERVER1_USER = "user-name";
        protected string NODE_DB_SERVER1_PASSWORD = "password";

        protected string NODE_DB_SERVER2 = "database2-connection";
        protected string NODE_DB_SERVER2_SERVERNAME = "server";
        protected string NODE_DB_SERVER2_DATABASE = "database-name";
        protected string NODE_DB_SERVER2_USER = "user-name";
        protected string NODE_DB_SERVER2_PASSWORD = "password";

        protected string NODE_CALBAR_FTP_ARCHIVE_DIRECTORY = "calbar-ftp-archives";
        protected string NODE_CALBAR_FTP_DELETE_ON_CLOUD = "calbar-ftp-delete";

        protected static string configFilePath = @"c:\MentechLogs\Calbarapp\CalbarDataMoverConfig.xml";

        public string Database1Server { get; set; }
        public string Database1DatabaseName { get; set; }
        public string Database1User { get; set; }
        public string Database1Password { get; set; }

        public string Database2Server { get; set; }
        public string Database2DatabaseName { get; set; }
        public string Database2User { get; set; }
        public string Database2Password { get; set; }

        #endregion

        #region Events / Delegates
        #endregion

        #region Constructor

        public BlinkSyncConfig()
            : base(configFilePath)
        {

        }
        public BlinkSyncConfig(string configPath)
          : base(configPath)
        {
            ConfigFilePath = configPath;

            TemplateFilesSourceDirectory = GetStringConfigValue(NODE_TEMPLATE_FILES_SOURCE_DIRECTORY);
            TemplateFilesDestinationDirectory = GetStringConfigValue(NODE_TEMPLATE_FILES_DESTINATION_DIRECTORY);


            PullOrigin = GetPullCalbarFilesOrigin();
            PullDestination = GetStringConfigValue(NODE_PULL_CALBAR_FILES_DESTINATION);
            PullErrorDestination = GetStringConfigValue(NODE_PULL_CALBAR_FILES_ERROR_DESTINATION);
            PullTempDirectory = GetStringConfigValue(NODE_PULL_CALBAR_TEMP_DIRECTORY);
            PushOrigin = GetStringConfigValue(NODE_PUSH_CALBAR_FILES_ORIGIN);
            PushDestination = GetStringConfigValue(NODE_PUSH_CALBAR_FILES_DESTINATION);
            PushErrorDestination = GetStringConfigValue(NODE_PUSH_CALBAR_FILES_ERROR_DESTINATION);
            PushTempDirectory = GetStringConfigValue(NODE_PUSH_CALBAR_TEMP_DIRECTORY);

            PullUploadLIVOrigin = GetStringConfigValue(NODE_PULL_CALBAR_UPLOAD_LIV_ORIGIN);
            PullUploadSqlInsertsOrigin = GetStringConfigValue(NODE_PULL_CALBAR_UPLOAD_SQLINSERTS_ORIGIN);

            CalbarFtpArchiveDirectory = GetCalbarFtpArchiveDirectory();
            SftpServer = GetSftpServer();
            SftpUser = GetSftpUser();
            SftpPassword = GetSftpPassword();
            DeleteOnCloud = GetStringConfigValue(NODE_CALBAR_FTP_DELETE_ON_CLOUD);

            Database1Server = GetDatabase1Server();
            Database1DatabaseName = GetDatabase1DatabaseName();
            Database1User = GetDatabase1User();
            Database1Password = GetDatabase1Password();

            Database2Server = GetDatabase2Server();
            Database2DatabaseName = GetDatabase2DatabaseName();
            Database2User = GetDatabase2User();
            Database2Password = GetDatabase2Password();

        }
        #endregion

        #region Properties
        public string TemplateFilesSourceDirectory { get; set; }

        public string TemplateFilesDestinationDirectory { get; set; }



        public string PullOrigin { get; set; }
        public string PullDestination { get; set; }
        public string PullErrorDestination { get; set; }
        public string PullTempDirectory { get; set; }
        public string PushOrigin { get; set; }
        public string PushDestination { get; set; }
        public string PushErrorDestination { get; set; }
        public string PushTempDirectory { get; set; }

        public string PullUploadLIVOrigin { get; set; }
        public string PullUploadSqlInsertsOrigin { get; set; }

        /// <summary>
        /// Path to directory on sftp server containing the calbar zip files
        /// </summary>
        public string CalbarFtpArchiveDirectory { get; set; }

        public string SftpServer { get; set; }
        public string SftpUser { get; set; }
        public string SftpPassword { get; set; }
        public string DeleteOnCloud { get; set; }
        #endregion

        #region Methods
        public virtual string GetDatabase1Server()
        {
            try
            {
                var recipients = ConfigFile.Descendants(NODE_DB_SERVER1).FirstOrDefault();

                if (recipients == null) { return string.Empty; }

                var data = recipients.Descendants(NODE_DB_SERVER1_SERVERNAME).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }
        public virtual string GetDatabase1DatabaseName()
        {
            try
            {
                var recipients = ConfigFile.Descendants(NODE_DB_SERVER1).FirstOrDefault();

                if (recipients == null) { return string.Empty; }

                var data = recipients.Descendants(NODE_DB_SERVER1_DATABASE).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }
        public virtual string GetDatabase1User()
        {
            try
            {
                var recipients = ConfigFile.Descendants(NODE_DB_SERVER1).FirstOrDefault();

                if (recipients == null) { return string.Empty; }

                var data = recipients.Descendants(NODE_DB_SERVER1_USER).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }
        public virtual string GetDatabase1Password()
        {
            try
            {
                var recipients = ConfigFile.Descendants(NODE_DB_SERVER1).FirstOrDefault();

                if (recipients == null) { return string.Empty; }

                var data = recipients.Descendants(NODE_DB_SERVER1_PASSWORD).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }

        public virtual string GetDatabase2Server()
        {
            try
            {
                var recipients = ConfigFile.Descendants(NODE_DB_SERVER2).FirstOrDefault();

                if (recipients == null) { return string.Empty; }

                var data = recipients.Descendants(NODE_DB_SERVER2_SERVERNAME).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }
        public virtual string GetDatabase2DatabaseName()
        {
            try
            {
                var recipients = ConfigFile.Descendants(NODE_DB_SERVER2).FirstOrDefault();

                if (recipients == null) { return string.Empty; }

                var data = recipients.Descendants(NODE_DB_SERVER2_DATABASE).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }
        public virtual string GetDatabase2User()
        {
            try
            {
                var recipients = ConfigFile.Descendants(NODE_DB_SERVER2).FirstOrDefault();

                if (recipients == null) { return string.Empty; }

                var data = recipients.Descendants(NODE_DB_SERVER2_USER).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }
        public virtual string GetDatabase2Password()
        {
            try
            {
                var recipients = ConfigFile.Descendants(NODE_DB_SERVER2).FirstOrDefault();

                if (recipients == null) { return string.Empty; }

                var data = recipients.Descendants(NODE_DB_SERVER2_PASSWORD).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }

        public virtual string GetSftpServer()
        {
            try
            {
                var recipients = ConfigFile.Descendants(NODE_CALBAR_SFTP_NODE).FirstOrDefault();

                if (recipients == null) { return string.Empty; }

                var data = recipients.Descendants(NODE_CALBAR_SFTP_SERVER).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }
        public virtual string GetSftpUser()
        {
            try
            {
                var recipients = ConfigFile.Descendants(NODE_CALBAR_SFTP_NODE).FirstOrDefault();

                if (recipients == null) { return string.Empty; }

                var data = recipients.Descendants(NODE_CALBAR_SFTP_USER).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }
        public virtual string GetSftpPassword()
        {
            try
            {
                var recipients = ConfigFile.Descendants(NODE_CALBAR_SFTP_NODE).FirstOrDefault();

                if (recipients == null) { return string.Empty; }

                var data = recipients.Descendants(NODE_CALBAR_SFTP_PASSWORD).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }
        public virtual string GetCalbarFtpArchiveDirectory()
        {
            try
            {
                var data = ConfigFile.Descendants(NODE_CALBAR_FTP_ARCHIVE_DIRECTORY).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }
        public virtual string GetPullCalbarFilesOrigin()
        {
            try
            {
                var data = ConfigFile.Descendants(NODE_PULL_CALBAR_FILES_ORIGIN).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }
        public virtual string GetStringConfigValue(string nodeName)
        {
            try
            {
                var data = ConfigFile.Descendants(nodeName).FirstOrDefault();
                return data == null ? string.Empty : data.Value;
            }
            catch { return string.Empty; }
        }
        #endregion

    }
}
