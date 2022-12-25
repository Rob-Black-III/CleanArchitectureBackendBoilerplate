namespace CleanArchitectureBoilerplate.API.APIResponseWrapper
{
    // Seems archaic to do it this way, but its cleaner than modifying the HTTP response body directly via streams
    // The responsibility of the controllers will be do inject this service. 
    // The middleware will handle populating traceID and other variables, 
    // all the controller will be responsible for is the payload, since that is not easily populated via middleware.
    // TODO if an easy way to populate existing response payload, get rid of this service entirely.
    public class APIResponseService : IAPIResponseService
    {
        private APIResponse Response;
        public APIResponseService(){
            Response = new APIResponse();

        }
        public APIResponse GetResponseObject()
        {
            return Response;
        }
    }
}