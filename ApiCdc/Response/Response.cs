
using System;
using System.Xml;

namespace ApiCdc
{
    public abstract class Response<T>
    {
        public T Data { get; set; }

        /// <summary>
        /// Error message that can be display or log
        /// when ReturnCode != OK
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Error message Detail that can be display or log
        /// when ReturnCode != OK
        /// </summary>
        public string ErrorMessageDetail { get; set; }

        public void Load(CdcResponse resp)
        {
            if (resp.ReturnCode != CdcRequestCode.OK)
            {
                try
                {
                    this.ErrorMessage = resp.Response.SelectNodes("/local-exception/local-message/local-title")[0].InnerText;
                    this.ErrorMessageDetail = string.Empty;
                    foreach (XmlNode n in resp.Response.SelectNodes("/local-exception/local-message/local-error"))
                    {
                        this.ErrorMessageDetail += n.InnerText + " \n";
                    }
                }
                catch (Exception e)
                {
                    if (string.IsNullOrEmpty(this.ErrorMessage))
                        this.ErrorMessage = "Error on reading error message:" + e.Message;

                    if (string.IsNullOrEmpty(this.ErrorMessageDetail))
                        this.ErrorMessageDetail = "Error on reading detail error message:" + e.Message;
                }
            }
            else
            {
                this.LoadXmlData(resp.Response);
            }
        }

        /// <summary>
        /// Fonction to load xml Data
        /// </summary>
        /// <param name="doc">doc to parse</param>
        public abstract void LoadXmlData(XmlDocument doc);
    }
}
