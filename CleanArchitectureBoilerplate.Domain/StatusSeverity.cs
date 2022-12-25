namespace CleanArchitectureBoilerplate.Domain
{
    public enum StatusSeverity {
        PRIVATE_INFO, // Will be logged internally, not populated to presentation layer.
        INFO, // Will be logged and sent to presentation.
        WARN, // Will be logged and sent to presentaiton.
        UNEXPECTED_ERROR, // Will be logged and sent to presentation for a toast (or maybe modal)
        EXPECTED_ERROR // Will be logged, sent to presentation, and assigned a {traceID}. For a modal.
    }
}
