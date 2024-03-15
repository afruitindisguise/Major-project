using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Major_Project.errors{
    public class UserNameNotFoundError : Exception{
        public ModelStateDictionary ModelState { get; set; }
        public UserNameNotFoundError(string message, ModelStateDictionary modelState) : base(message){
            this.ModelState = modelState;
        }
    }
}