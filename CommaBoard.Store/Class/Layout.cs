using System;
using System.Collections.Generic;
using System.Text;

namespace CommaBoard.Store.Class
{
    public class Layout
    {

        public Guid id { get; set; }
        public Guid parentId { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Guid typeId { get; set; }
        public float cellAspectRatio { get; set; }
        public float cellSpacing { get; set; }
        public LayoutItem[] items { get; set; }
        public bool locked { get; set; }
        public int fixedWidth { get; set; }
        public int fixedHeight { get; set; }
        public int logicalId { get; set; }
        public string backgroundImageFilename { get; set; }
        public int backgroundWidth { get; set; }
        public int backgroundHeight { get; set; }
        public float backgroundOpacity { get; set; }

    }

    public class LayoutItem
    {

        public Guid id { get; set; }
        public int flags { get; set; }
        public float left { get; set; }
        public float top { get; set; }
        public float right { get; set; }
        public float bottom { get; set; }
        public float rotation { get; set; }
        public Guid resourceId { get; set; }
        public string resourcePath { get; set; }
        public float zoomLeft { get; set; }
        public float zoomTop { get; set; }
        public float zoomRight { get; set; }
        public float zoomBottom { get; set; }
        public Guid zoomTargetId { get; set; }
        public ContrastParams contrastParams { get; set; }
        public DewarpingParams dewarpingParams { get; set; }
        public bool displayInfo { get; set; }
        public bool displayAnalyticsObjects { get; set; }
        public bool displayRoi { get; set; }

    }

    public class ContrastParams
    {
        public bool enabled { get; set; }
        public float blackLevel { get; set; }
        public float whiteLevel { get; set; }
        public float gamma { get; set; }

    }

    public class DewarpingParams
    {
        public bool enabled { get; set; }
        public float xAngle { get; set; }
        public float yAngle { get; set; }
        public float fov { get; set; }
        public int panoFactor { get; set; }
    }



}
