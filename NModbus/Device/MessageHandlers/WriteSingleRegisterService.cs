﻿using System.Linq;
using NModbus.Message;

namespace NModbus.Device.MessageHandlers
{
    internal class WriteSingleRegisterService : ModbusFunctionServiceBase<WriteSingleRegisterRequestResponse>
    {
        public WriteSingleRegisterService() 
            : base(ModbusFunctionCodes.WriteSingleRegister)
        {
        }

        public override int GetRtuRequestBytesToRead(byte[] frameStart)
        {
            return 1;
        }

        public override int GetRtuResponseBytesToRead(byte[] frameStart)
        {
            return 4;
        }

        protected override IModbusMessage Handle(WriteSingleRegisterRequestResponse request, ISlaveDataStore dataStore)
        {
            ushort[] points = request.Data
                .ToArray();

            dataStore.HoldingRegisters.WritePoints(request.StartAddress, points);

            return request;
        }
    }
}