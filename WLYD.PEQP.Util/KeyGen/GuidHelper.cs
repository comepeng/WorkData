using System;

namespace Compeng.PEQP.Util.KeyGen
{
    public static  class GuidHelper
    {
         public static Guid NewGuid()
        {
            return SequentialGuidGenerator.Instance.Create();
        }
    }
}
