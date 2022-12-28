namespace CleanArchitectureBoilerplate.Domain
{
    public enum StatusSeverity {
        DEBUG,
        INFO,
        WARN,
        UNEXPECTED_ERROR, // Will be logged and sent to presentation for a toast (or maybe modal)
        EXPECTED_ERROR // Will be logged, sent to presentation, and assigned a {traceID}. For a modal.
    }
}
