using System;
using System.Reflection;

namespace RoboCode.Runner.FrameworkExtensions
{
  public static class EventInfoExtensions
  {
    public static Delegate ConvertDelegate(
      this EventInfo instance, Delegate action)
    {
      return Delegate.CreateDelegate(
        instance.EventHandlerType, action.Target, action.Method);
    }
  }
}
