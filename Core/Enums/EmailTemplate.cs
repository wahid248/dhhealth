using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Enums.EmailTemplate
{
    public enum EmailTemplates
    {
        UserConfirmation = 1,
        UserQueryToAdmin,
        JobApplyConfirmation,
        AppliedJobToAdmin,
        NewsSubscription
    }
}
