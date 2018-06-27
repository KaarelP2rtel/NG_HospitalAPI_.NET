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
            AddMessages(messages);
        }

        public List<MessageDTO> Messages { get; set; } = new List<MessageDTO>();
        public void AddMessages(params string[] messages)
        {
            Messages.AddRange(messages.Select(m => new MessageDTO { Message = m }));
        }
    }
    
    public class MessageDTO
    {
        public string Message { get; set; }
    }
}
