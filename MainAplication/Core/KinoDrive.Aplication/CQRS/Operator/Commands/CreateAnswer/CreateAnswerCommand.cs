﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoDrive.Aplication.CQRS.Operator.Commands.CreateAnswer
{
    public class CreateAnswerCommand : IRequest
    {
        public int ComplaintId { get; set; }
        public string Text { get; set; }
    }
}
