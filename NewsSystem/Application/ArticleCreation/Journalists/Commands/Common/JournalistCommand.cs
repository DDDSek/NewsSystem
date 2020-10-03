﻿namespace NewsSystem.Application.ArticleCreation.Journalists.Commands.Common
{
    using NewsSystem.Application.Common;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class JournalistCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string UserId { get; set; } = default!;

        public string Address { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;


    }
}
