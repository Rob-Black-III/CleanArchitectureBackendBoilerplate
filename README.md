# BackendBoilerplate
.NET CORE 7, FLUENT API, EF CORE

TODO need to return response payload, with additonal meta-details for toast message(s)
Common implementations like Result<>, ErrorOr<>, ProblemDetails, etc. 

I think best approach is returning JSON object with additional meta-fields, dynamic payload variable,
and a contained ProblemDetails-like object.

From our controller, we return a generic 

CleanArchitecturePresentationResult{
    // {Other non-endpoint-specific, meta variables we might care about}
    dynamic payload; // Actual endpoint-specific response
    int httpStatusCode;

    MyCustomProblemDetailsishObject{
        // Normal problem details struct maybe? https://www.rfc-editor.org/rfc/rfc7807
        serverity: {INFO || WARN || KNOWN_ERROR || UNKNOWN_ERROR} // Errors ~ Exceptions, but not neccesarily.
            // INFO will be an info toast on frontend. 
            // WARN will be "recommendations". Non-critical suggestions. Toast
                // ex. Hey, maybe don't leave the description empty when entering a new product
            // KNOWN_ERROR
                // Return details as to why the operation cannot be completed.
                    // ex. Product inventory must be a non-negative integer, you entered '-2'. Toast?
            // UNKNOWN_ERROR
                // Instead of toasts. Put everything into a modal list of errors.
                // Include a {traceID} that corresponds to the entire HTTP request pipeline on the backend.
                    // I can include that in the CloudWatch/CloudFront logging for further analysis in PROD.
    }
}

NO ERRORS & NO MESSAGES
NO ERRORS & INFO &/OR WARNINGS
ERRORS...


Problem Details
TODO Global Error and Exception Handling (RFC 7807 - Problem Details?)
  - TODO additional flags to return to frontend as toasts. For INFO, WARN, ERROR (i.e. Status, Recommendation, and Task-Completion issue)
TODO Global Logging (via Serilog? to AWS?)
TODO Middleware Validation (Mediatr pipelines? RequestDelegate? FluentAPIValidation?)
