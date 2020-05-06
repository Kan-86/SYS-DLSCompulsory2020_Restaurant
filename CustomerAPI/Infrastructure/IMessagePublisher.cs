using System.Collections.Generic;
using SharedModels;

namespace CustomerAPI.Infrastructure
{
    public interface IMessagePublisher
    {
        void PublishOrderStatusChangedMessage(int? customerId,
            IList<OrderLine> orderLines, string topic);
    }
}
