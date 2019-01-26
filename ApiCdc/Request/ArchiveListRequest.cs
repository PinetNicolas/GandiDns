using System;
using System.Collections.Generic;

namespace ApiCdc
{
    public enum ArchiveListRequestFilterOperator
    {
        None,
        Superior,
        Equals,
        Inferior
    }

    public class ArchiveListRequestFilter
    {
        public string Key { get; set; }
        public ArchiveListRequestFilterOperator Operator { get; set; } = ArchiveListRequestFilterOperator.None;
        public string Value { get; set; }

    }
    
    /// <summary>
    /// Class for Archive list request
    /// </summary>
    public class ArchiveListRequest
    {
        /// <summary>
        /// Section identifiant to search
        /// </summary>
        public string SectionId { get; set; }

        private List<ArchiveListRequestFilter> _metadataFilter;
        private List<ArchiveListRequestFilter> _dublinCoreFilter;

        private DateTime _depositDateLowerBound = DateTime.MinValue;
        private DateTime _depositDateUpperBound = DateTime.MinValue;

        public ArchiveListRequest(string sectionId)
        {
            SectionId = sectionId;
            _metadataFilter = new List<ArchiveListRequestFilter>();
            _dublinCoreFilter = new List<ArchiveListRequestFilter>();
        }

        /// <summary>
        /// Add a Filter to request.
        /// </summary>
        /// <param name="metadataKey">the metadata key</param>
        /// <param name="op">the operator to apply</param>
        /// <param name="metadataValue">the value to filter</param>
        /// <returns>false if key is not valid else true</returns>
        public bool AddMetadataFilter(string metadataKey, ArchiveListRequestFilterOperator op, string metadataValue)
        {
            _metadataFilter.Add(new ArchiveListRequestFilter() { Key = metadataKey, Operator = op, Value = metadataValue });
            return true;
        }

        /// <summary>
        /// Add a Filter to request.
        /// </summary>
        /// <param name="metadataKey">the metadata key</param>
        /// <param name="metadataValue">the value to filter</param>
        /// <returns>false if key is not valid else true</returns>
        public bool AddMetadataFilter(string metadataKey, string metadataValue)
        {
            _metadataFilter.Add(new ArchiveListRequestFilter() { Key = metadataKey, Value = metadataValue });
            return true;
        }

        /// <summary>
        /// Add a Filter to request.
        /// </summary>
        /// <param name="dublinCoreKey">the dublin core key</param>
        /// <param name="op">the operator to apply</param>
        /// <param name="dublinCoreValue">the value to filter</param>
        /// <returns>false if key is not valid else true</returns>
        public bool AddDublinCoreFilter(string dublinCoreKey, ArchiveListRequestFilterOperator op, string dublinCoreValue)
        {
            _dublinCoreFilter.Add(new ArchiveListRequestFilter() { Key = dublinCoreKey, Operator = op, Value = dublinCoreValue });
            return true;
        }

        /// <summary>
        /// Add a Filter to request.
        /// </summary>
        /// <param name="dublinCoreKey">the dublin core key</param>
        /// <param name="dublinCoreValue">the value to filter</param>
        /// <returns>false if key is not valid else true</returns>
        public bool AddDublinCoreFilter(string dublinCoreKey, string dublinCoreValue)
        {
            _dublinCoreFilter.Add(new ArchiveListRequestFilter() { Key = dublinCoreKey, Value = dublinCoreValue });
            return true;
        }

        /// <summary>
        /// Add a deposit date filter
        /// </summary>
        /// <param name="lowerBound">The lower bound to search</param>
        /// <param name="upperBound">The upper bound to search</param>
        /// <returns>false if lowerBound > upperBound</returns>
        public bool AddDepositDateFilter(DateTime lowerBound, DateTime upperBound)
        {
            if(lowerBound!= DateTime.MinValue && upperBound != DateTime.MinValue && lowerBound > upperBound)
            {
                return false;
            }

            _depositDateLowerBound = lowerBound;
            _depositDateUpperBound = upperBound;
            return true;
        }

        /// <summary>
        /// Construction of the parameter request
        /// </summary>
        /// <returns>the string ready to send</returns>
        public string GetParameters()
        {
            string retour = string.Empty ;

            string metadataFiltre = GenerateParameter(_metadataFilter, "applicativeMetadataOp", "applicativeMetadata");
            if(!string.IsNullOrEmpty(metadataFiltre))
            {
                retour = "?" + metadataFiltre.Substring(1);
            }

            string dublinCoreFiltre = GenerateParameter(_dublinCoreFilter, "dublinCoreOp", "dublinCore");
            if (!string.IsNullOrEmpty(dublinCoreFiltre))
            {
                if (string.IsNullOrEmpty(retour))
                {
                    retour = "?" + dublinCoreFiltre.Substring(1);
                }
                else
                {
                    retour += dublinCoreFiltre;
                }
            }

            if (_depositDateLowerBound != DateTime.MinValue)
            {
                if (string.IsNullOrEmpty(retour))
                {
                    retour = "?depositDateLowerBound=" + Tools.convertToCdcDateTime(_depositDateLowerBound);
                }
                else
                {
                    retour += "&depositDateLowerBound=" + Tools.convertToCdcDateTime(_depositDateLowerBound);
                }
            }

            if (_depositDateUpperBound != DateTime.MinValue)
            {
                if (string.IsNullOrEmpty(retour))
                {
                    retour = "?depositDateUpperBound=" + Tools.convertToCdcDateTime(_depositDateUpperBound);
                }
                else
                {
                    retour += "&depositDateUpperBound=" + Tools.convertToCdcDateTime(_depositDateUpperBound);
                }
            }

            return retour;
        }

        /// <summary>
        /// GEnerate a list of parameter
        /// </summary>
        /// <param name="filtrelist">List of filtre to add</param>
        /// <param name="parameterOp">parameter operator name in url</param>
        /// <param name="parameterName">parameter name in url</param>
        /// <returns></returns>
        public string GenerateParameter(List<ArchiveListRequestFilter> filtrelist, string parameterOp, string parameterName)
        {
            string retour = string.Empty;
            foreach (ArchiveListRequestFilter filter in filtrelist)
            {
                if (filter.Operator != ArchiveListRequestFilterOperator.None)
                {
                    retour += $"&{parameterOp}[{filter.Key}]=";
                    switch (filter.Operator)
                    {
                        case ArchiveListRequestFilterOperator.Superior:
                            retour += "superior";
                            break;

                        case ArchiveListRequestFilterOperator.Equals:
                            retour += "equals";
                            break;
                        case ArchiveListRequestFilterOperator.Inferior:
                            retour += "inferior";
                            break;
                    }
                }

                retour += $"&{parameterName}[{filter.Key}]={filter.Value}";
            }

            return retour;
        }
    }
}
