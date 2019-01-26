using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ApiCdc
{
    /// <summary>
    /// Class for put file request
    /// Make some calculation and test data before send
    /// </summary>
    public class SendFileRequest
    {
        /// <summary>
        /// Liste des clés autorisé pour le parametre dublinCore
        /// </summary>
        public readonly static List<string> KeyDublin = new List<string>(){
                        "title","creator","subject","description", "publisher", "contributor",
                        "date","type","format","identifier","source","language","relation",
                        "coverage","rights"};

        /// <summary>
        /// Path name
        /// </summary>
        private string _fileName;

        #region CDC parameter
        /// <summary>
        /// name: initialEndOfLifeDate, type: date spécifié sous le format
        /// AAAA-MM-JJ hh:mm:ss,xxx.Ce format peut être incomplet(par exemple : 2027-10-25). 
        ///     Ce paramètre est optionnel.
        /// 
        /// Lors du dépôt d’une archive, la date initiale de fin de vie associée à l’archive est :
        ///         • soit spécifiée au moment du dépôt par le paramètre : initialEndOfLifeDate,
        ///         • soit calculée en ajoutant la durée de conservation par défaut
        ///                 spécifiée au niveau de la section à la date de dépôt.
        /// Lorsque la date initiale de fin de vie est précisée au moment du dépôt,
        /// elle ne peut pas être postérieure à la date qui aurait été calculée.
        /// Lorsque des opérations de prorogation ou d’abrégement de la durée de
        /// conservation vont intervenir, cette date de fin de vie, contenue dans les
        /// métadonnées administratives va donc évoluer.
        /// 
        /// A chaque mise à jour de cette date, une nouvel ARF sera transmis au
        /// client, ainsi qu’une attestation signée de changement de date de fin de vie.
        /// </summary>
        private string _initialEndOfLifeDate;

        /// <summary>
        /// name: dublinCore[xxx], type: text où xxx peut prendre les valeurs suivantes :
        ///     title, creator, subject, description, date, type, format, identifier, source, language, relation.
        /// 
        /// Le format de la date doit être sous la forme AAAA-MM-JJ hh:mm:ss,xxx 
        ///     au maximum de précision, les formats, AAAA, AAAAMM, … sont également acceptés.
        /// 
        /// Ces paramètres « dublinCore » peuvent être répétés autant de fois que désiré.
        /// </summary>
        private Dictionary<string, List<string>> _dublinCore;

        /// <summary>
        /// name: applicativeMetadata, type: text
        /// Chaine de caractère représentant les métadonnées applicatives.
        /// 
        /// Il est important de penser à protéger dans les données les caractères
        /// réservés du format XML :
        /// Caractère   Equivalent XML
        ///    "            &quot;
        ///    '            &apos;
        ///    <            &lt;
        ///    >            &gt;
        ///    &            &amp;
        /// Le non-respect du format des métadonnées définies par le DMD entraine le rejet de l’archive 
        /// avec une erreur http 400.
        /// </summary>
        private XmlDocument _applicativeMetadata;

        /// <summary>
        /// name: appMetadataDigest, type: text
        /// Optionnel, empreinte SHA-256, encodée base64, des métadonnées applicatives.
        /// Si ce paramètre est présent, l’empreinte fournie par le client est comparée à l’empreinte 
        /// calculée côté serveur.Si celles-ci ne sont pas égales, l’archive est refusée 
        /// via une réponse HTTP 400 (Bad request)
        /// </summary>
        private string _appMetadataDigest;

        /// <summary>
        /// name: dataObjectDigest, type: text
        /// Optionnel, empreinte SHA-256, encodée base64, de l’objet-donnée.
        /// Si ce paramètre est présent, l’empreinte fournie par le client est comparée à l’empreinte 
        /// calculée côté serveur.Si celles-ci ne sont pas égales, l’archive est refusée 
        /// via une réponse HTTP 400 (Bad request).
        /// </summary>
        private string _dataObjectDigest;

        /// <summary>
        /// name: dataObject, type: file
        /// Attention ! Ce paramètre doit être le dernier passé, 
        /// sans quoi les paramètres qui suivent seront tous ignorés
        /// Le nom du fichier(« filename ») ainsi que son « content-type » (ex : text/plain; charset=ISO-8859-1) 
        /// sont conservés dans l’archive et doivent donc être également envoyés afin de pouvoir
        /// récupérer ultérieurement correctement l’archive.
        /// Le SAE dans un premier temps va caractériser le format du fichier envoyé.
        /// Suivant ce qui a été convenu, l’archive peut être refusée avec un code http 400 si son format 
        /// n’est pas reconnu.Aujourd’hui environ 1207 types de fichiers sont reconnus. 
        /// Dans le cas où le fichier transmis est crypté ou bien spécifique, ce contrôle pourra être non bloquant.
        /// Parmi les fichiers reconnus, certains pourrons être validés par le SAE.
        /// Il s’agit d’une étape consistant à vérifier que le fichier répond bien à la norme de son format. 
        /// Par exemple PDF, XML, texte brut etc.Suivant ce qui a été paramétré, 
        /// les archives dont le fichier n’est pas validé pourront être refusées avec un code http 400.
        /// Ainsi, il est fortement encouragé à n’utiliser que des formats dit « pérennes ». 
        /// Il s’agit d’un plus permettant au SAE de s’engager plus fortement sur la lisibilité du document à 
        /// long terme. Si le format envisagé peut être considéré comme pérenne mais ne fait pas partis des formats
        /// valables par le SAE, le client pourra faire une demande au support afin que ce format soit rajouté.
        /// Les formats gérés par le SAE sont décrit dans le document : E-MA-20_LISTE-FORMATS.pdf
        /// </summary>
        private byte[] _dataObject;
        #endregion

        /// <summary>
        /// Constructeur with simple parameter
        /// </summary>
        /// <param name="sectionId"></param>
        public SendFileRequest(string sectionId)
        {
            _dublinCore = new Dictionary<string, List<string>>();
            SectionId = sectionId;
        }

        /// <summary>
        /// The section Id
        /// </summary>
        public string SectionId { get; }

        /// <summary>
        /// Add a string parameter to dublin core.
        /// </summary>
        /// <param name="key">key of parameter</param>
        /// <param name="value">value to add</param>
        /// <returns>false if key is not valid else true</returns>
        public bool AddDublinCoreParameter(string key, string value)
        {
            if( KeyDublin.Contains(key))
            {
                if (!_dublinCore.ContainsKey(key))
                    _dublinCore.Add(key, new List<string>());
                _dublinCore[key].Add(value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Add a DateTime parameter to dublin core.
        /// Convert to the good format in order to control validity
        /// </summary>
        /// <param name="key">key of parameter</param>
        /// <param name="value">value to add</param>
        /// <returns>false if key is not valid else true</returns>
        public bool AddDublinCoreDateParameter(string key, DateTime value)
        {
            return AddDublinCoreParameter(key, Tools.convertToCdcDateTime(value));
        }

        /// <summary>
        /// Add a DateTime to Endoflife parameter
        /// Optional parameter
        /// </summary>
        /// <param name="value">value to add</param>
        /// <returns>false if key is not valid else true</returns>
        public bool AddEndofLife(DateTime value)
        {
            _initialEndOfLifeDate = Tools.convertToCdcDateTime(value);
            return true;
        }

        /// <summary>
        /// Add applicative metadata to request
        /// Calculation of digest
        /// </summary>
        /// <param name="doc">Xml document to add</param>
        /// <returns>true if add correctly</returns>
        public bool AddApplicativeMetadata(string key, string value)
        {
            if(_applicativeMetadata == null)
            {
                _applicativeMetadata = new XmlDocument();
                XmlNode docNode = _applicativeMetadata.CreateXmlDeclaration("1.0", "UTF-8", null);
                _applicativeMetadata.AppendChild(docNode);
                XmlNode first = _applicativeMetadata.CreateElement("e-vault_metadata");
                _applicativeMetadata.AppendChild(first);
            }

            XmlNode root = _applicativeMetadata.ChildNodes[1];
            // Create and append a child element for the title of the book.
            XmlElement newElement = _applicativeMetadata.CreateElement(key);
            newElement.InnerText = System.Security.SecurityElement.Escape(value);
            root.AppendChild(newElement);
            return true;
        }

        /// <summary>
        /// Add file to request
        /// </summary>
        /// <param name="filePath">File content</param>
        /// <param name="fileDigest">File digest already calculate</param>
        /// <returns>true if add correctly</returns>
        public bool AddDataObject(string filePath, string fileDigest)
        {
            System.IO.FileInfo f = new System.IO.FileInfo(filePath);

            _fileName = f.Name;
            _dataObject = System.IO.File.ReadAllBytes(filePath);
            string disgestCalculate = Tools.CalculHash(_dataObject);
            if (string.IsNullOrEmpty(fileDigest))
                _dataObjectDigest = disgestCalculate;
            else if (fileDigest == disgestCalculate)
                _dataObjectDigest = fileDigest;
            else
                return false;
            return true;
        }

        /// <summary>
        /// Construction of the parameter request
        /// </summary>
        /// <returns>the string ready to send</returns>
        public MultipartFormDataContent GetContent()
        {
            MultipartFormDataContent retour = new MultipartFormDataContent();
            //Dictionary<string,string> retour = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(_initialEndOfLifeDate))
            {
                retour.Add(new StringContent(_initialEndOfLifeDate), "initialEndOfLifeDate");
            }

            foreach (string key in _dublinCore.Keys)
            {
                foreach (string value in _dublinCore[key])
                {
                    retour.Add(new StringContent(value), $"dublinCore[{key}]");
                }
            }

            string applicativeMetadata = _applicativeMetadata.OuterXml;
            _appMetadataDigest = Tools.CalculHash(applicativeMetadata);
            retour.Add(new StringContent(applicativeMetadata), "applicativeMetadata");

            if (!string.IsNullOrEmpty(_appMetadataDigest))
            {
                retour.Add(new StringContent(_appMetadataDigest), "appMetadataDigest");
            }

            if (!string.IsNullOrEmpty(_dataObjectDigest))
            {
                retour.Add(new StringContent(_dataObjectDigest), "dataObjectDigest");
            }

            // dataObject must be the last
            retour.Add(new ByteArrayContent(_dataObject), "dataObject", _fileName);
            return retour;
        }
    }
}
