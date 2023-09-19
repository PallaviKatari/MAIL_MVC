﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAIL_MVC.Models
{
    public class EmailModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public HttpPostedFileBase Attachment { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}