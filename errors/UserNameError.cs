using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Major_Project.errors{
    public class UserNameExistsError : Exception{
        public UserNameExistsError(string message) : base(message){
        }
    }
}