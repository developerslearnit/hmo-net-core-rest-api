using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Notifications
{
    public class EmailViewModel
    {
        public Guid EmailLogId { get; set; }
        public string UserId { get; set; }
        public string RequestReference
        {

            get; set;
        }
        public string AttachmentFileUrl
        {

            get; set;
        }
        public string RecipientEmailAddress
        {

            get; set;
        }

        public string MailBody
        {

            get; set;
        }

        public string MessageTitle
        {

            get; set;
        }

        public bool HasAttachment
        {

            get; set;
        }

        public string AttachmentFileName
        {

            get; set;
        }

        public bool SendSuccessfully
        {
            get; set;
        }

        public string SendStatus
        {

            get;

            set;
        }

        public DateTime? SendDateAndTime
        {

            get;

            set;
        }

        public bool IsProcessing
        {

            get;

            set;
        }

        public bool IsProcessed
        {

            get;

            set;
        }
    }
}
