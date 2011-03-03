using System;

namespace MotoTrak.Entities
{
    public class AttachmentEntity : Entity
    {
        private int _linkId;
        private string _fileName = "";
        private string _contentType = "";
        private int _contentSize;
        private string _contentPath = "";
        private AttachmentType _attachmentType;
        private int _siteId;

        public AttachmentEntity()
            : base()
        {
        }

        public int LinkId
        {
            get { return _linkId; }
            set { _linkId = value; }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }

        public int ContentSize
        {
            get { return _contentSize; }
            set { _contentSize = value; }
        }

        public string ContentPath
        {
            get { return _contentPath; }
            set { _contentPath = value; }
        }
        
        public AttachmentType AttachmentType
        {
            get { return _attachmentType; }
            set { _attachmentType = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }
    }
}