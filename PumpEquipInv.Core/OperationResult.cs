namespace PumpEquipInv.Core;

public class OperationResult(bool success, string message)
{
    public bool Success { get; set; } = success;
    public string Message { get; set; } = message;

    // Factory method for a successful operation
    public static OperationResult SuccessResult(string message = "Success")
    {
        return new OperationResult(true, message);
    }

    // Factory method for a failed operation
    public static OperationResult FailureResult(string message)
    {
        return new OperationResult(false, message);
    }
}