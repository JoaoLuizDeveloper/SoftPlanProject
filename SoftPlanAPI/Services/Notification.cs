using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SoftPlanAPI.Services
{
    public class Notification : IRequest, INotification
    {
        public string Description { get; private set; }

        public Type CommandType { get; private set; }

        #region Factory
        public  static class Factory
        {
            public static Notification Create(object commandType, string description)
                => new Notification()
                {
                    CommandType = commandType.GetType(),
                    Description = description
                };
        }
        #endregion
    }
}
