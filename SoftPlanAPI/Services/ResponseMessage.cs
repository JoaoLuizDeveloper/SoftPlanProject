using System.Runtime.Serialization;

namespace SoftPlanAPI.Services
{
    [DataContract]
    public struct ResponseMessage<TResult>
    {
        [DataMember(Name = "errors")]
        public string[] Errors { get; set; }

        [DataMember(Name = "data")]
        public TResult Data { get; }

        [DataMember(Name = "success")]
        public bool Success => !(Errors?.Length > 0);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="errors"></param>
        public ResponseMessage(TResult data, params string[] errors)
        {
            this.Data = data;
            this.Errors = errors;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ResponseMessage<TResult>(TResult value)
            => new ResponseMessage<TResult>(value, null);
    }
}
