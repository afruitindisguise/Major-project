using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Major_Project.errors{
    public class InvalidPassword : Exception{
        public ModelStateDictionary ModelState { get; set; }
        public InvalidPassword(string message, ModelStateDictionary modelState) : base(message){
            this.ModelState = modelState;
        }
    }
}