using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace AspNetCoreSampleApp.Models
{
    public class ErrorXMLModel
    {
    }

        [XmlRoot(ElementName = "Const")]
        public class Const
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlText]
            public string Text { get; set; }
        }

        [XmlRoot(ElementName = "Location")]
        public class Location
        {
            [XmlAttribute(AttributeName = "maxX")]
            public string MaxX { get; set; }
            [XmlAttribute(AttributeName = "maxY")]
            public string MaxY { get; set; }
            [XmlAttribute(AttributeName = "minX")]
            public string MinX { get; set; }
            [XmlAttribute(AttributeName = "minY")]
            public string MinY { get; set; }
            [XmlAttribute(AttributeName = "page")]
            public string Page { get; set; }
        }

        [XmlRoot(ElementName = "Instance")]
        public class Instance
        {
            [XmlElement(ElementName = "Location")]
            public List<Location> Location { get; set; }
            [XmlElement(ElementName = "Var")]
            public List<Var> Var { get; set; }
        }

        [XmlRoot(ElementName = "StringContext")]
        public class StringContext
        {
            [XmlElement(ElementName = "BaseString")]
            public string BaseString { get; set; }
            [XmlElement(ElementName = "Const")]
            public List<Const> Const { get; set; }
            [XmlElement(ElementName = "Instance")]
            public List<Instance> Instance { get; set; }
        }

        [XmlRoot(ElementName = "PreflightResultEntryMessage")]
        public class PreflightResultEntryMessage
        {
            [XmlElement(ElementName = "Message")]
            public string Message { get; set; }
            [XmlElement(ElementName = "StringContext")]
            public StringContext StringContext { get; set; }
            [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
            public string Lang { get; set; }
        }

        [XmlRoot(ElementName = "PreflightResultEntry")]
        public class PreflightResultEntry
        {
            [XmlElement(ElementName = "PreflightResultEntryMessage")]
            public PreflightResultEntryMessage PreflightResultEntryMessage { get; set; }
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "level")]
            public string Level { get; set; }
        }

        [XmlRoot(ElementName = "Var")]
        public class Var
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlText]
            public string Text { get; set; }
            [XmlElement(ElementName = "Var")]
            public List<Var> Vardata { get; set; }
        }

        [XmlRoot(ElementName = "PreflightResult")]
        public class PreflightResult
        {
            [XmlElement(ElementName = "PreflightResultEntry")]
            public List<PreflightResultEntry> PreflightResultEntry { get; set; }
            [XmlAttribute(AttributeName = "errors")]
            public string Errors { get; set; }
            [XmlAttribute(AttributeName = "criticalfailures")]
            public string Criticalfailures { get; set; }
            [XmlAttribute(AttributeName = "noncriticalfailures")]
            public string Noncriticalfailures { get; set; }
            [XmlAttribute(AttributeName = "signoffs")]
            public string Signoffs { get; set; }
            [XmlAttribute(AttributeName = "fixes")]
            public string Fixes { get; set; }
            [XmlAttribute(AttributeName = "warnings")]
            public string Warnings { get; set; }
        }

        [XmlRoot(ElementName = "Report")]
        public class Report
        {
            [XmlElement(ElementName = "PreflightResult")]
            public PreflightResult PreflightResult { get; set; }
        }

        [XmlRoot(ElementName = "EnfocusReport")]
        public class EnfocusReport
        {
            [XmlElement(ElementName = "Report")]
            public Report Report { get; set; }
        }
}
