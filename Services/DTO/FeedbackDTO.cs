using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.DTO
{
    public class FeedbackDTO
    {
        public FeedbackDTO(params string[] messages)
        {
            Messages = messages.Select(m => new MessageDTO {Message = m });
        }

        public IEnumerable<MessageDTO> Messages { get; set; }
    }

    public class MessageDTO
    {
        public string Message { get; set; }
    }
}
