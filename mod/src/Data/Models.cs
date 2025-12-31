using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StationpediaAscended.Data
{
    [Serializable]
    public class DescriptionsRoot
    {
        public string version;
        public List<DeviceDescriptions> devices;
        public GenericDescriptionsData genericDescriptions;
    }

    [Serializable]
    public class DeviceDescriptions
    {
        public string deviceKey;
        public string displayName;
        public string pageDescription;        // Replace entire description
        public string pageDescriptionAppend;  // Add to end of existing description
        public string pageDescriptionPrepend; // Add to beginning of existing description
        public Dictionary<string, LogicDescription> logicDescriptions;
        public Dictionary<string, ModeDescription> modeDescriptions;
        public Dictionary<string, SlotDescription> slotDescriptions;
        public Dictionary<string, VersionDescription> versionDescriptions;
        public Dictionary<string, MemoryDescription> memoryDescriptions;
        
        [JsonProperty("operationalDetails")]
        public List<OperationalDetail> operationalDetails;
        
        [JsonProperty("OperationalDetails")]
        public List<OperationalDetail> OperationalDetailsAlt { set { operationalDetails = value; } }
        
        public string operationalDetailsTitleColor; // Optional: hex color like "#FF7A18" for the category title
        
        /// <summary>If true, generates a Table of Contents panel at the top of Operational Details</summary>
        public bool generateToc { get; set; } = false;
        
        /// <summary>Custom title for the TOC panel (default: "Contents")</summary>
        public string tocTitle { get; set; }
        
        /// <summary>Custom background color for operational details sections (hex format)</summary>
        public string operationalDetailsBackgroundColor { get; set; }
    }

    [Serializable]
    public class LogicDescription
    {
        public string dataType;
        public string range;
        public string description;
    }

    [Serializable]
    public class ModeDescription
    {
        public string modeValue;
        public string description;
    }

    [Serializable]
    public class SlotDescription
    {
        public string slotType;
        public string description;
    }

    [Serializable]
    public class VersionDescription
    {
        public string description;
    }

    [Serializable]
    public class MemoryDescription
    {
        public string opCode;
        public string parameters;
        public string description;
        public string byteLayout;
    }

    [Serializable]
    public class OperationalDetail
    {
        public string title;
        public string description;
        
        // Nested content support
        public List<OperationalDetail> children;  // Nested subsections
        public List<string> items;                 // Bullet list items
        public List<string> steps;                 // Numbered step list
        
        // Advanced features
        /// <summary>If true, this detail renders as a collapsible StationpediaCategory instead of inline text</summary>
        public bool collapsible { get; set; } = false;
        
        /// <summary>If set, this section appears in the Table of Contents with this ID for scroll-to linking</summary>
        public string tocId { get; set; }
        
        /// <summary>If set, displays this image file (relative to mod images folder) inline</summary>
        public string imageFile { get; set; }
        
        /// <summary>Custom background color for this section (hex format like "#1A2B3C")</summary>
        public string backgroundColor { get; set; }
        
        /// <summary>If set, displays a clickable YouTube link that opens in the system browser</summary>
        public string youtubeUrl { get; set; }
        
        /// <summary>Custom label for the YouTube link (default: "Watch on YouTube")</summary>
        public string youtubeLabel { get; set; }
        
        /// <summary>If set, displays an embedded video player for this MP4/video file (relative to mod images folder)</summary>
        public string videoFile { get; set; }
    }

    [Serializable]
    public class PropertyDescription
    {
        public string type;
        public string threshold;
        public string description;
        public string formula;
    }

    [Serializable]
    public class GenericDescriptionsData
    {
        public Dictionary<string, string> logic;
        public Dictionary<string, string> slotTypes;
        public Dictionary<string, string> slots;
        public Dictionary<string, string> modes;
        public Dictionary<string, string> versions;
        public Dictionary<string, string> connections;
        public Dictionary<string, MemoryDescription> memory;
        public Dictionary<string, PropertyDescription> properties;
    }
}
