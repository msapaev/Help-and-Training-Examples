﻿using PX.Data;
using PX.Data.WorkflowAPI;
using static PX.Data.WorkflowAPI.BoundedTo<PhoneRepairShop.RSSVWorkOrderEntry,
  PhoneRepairShop.RSSVWorkOrder>;

namespace PhoneRepairShop.Workflows
{
    // Acuminator disable once PX1016 ExtensionDoesNotDeclareIsActiveMethod extension should be constantly active
    public class RSSVWorkOrderWorkflow :
      PX.Data.PXGraphExtension<RSSVWorkOrderEntry>
    {
        #region Constants
        public static class States
        {
            public const string OnHold = WorkOrderStatusConstants.OnHold;
            public const string ReadyForAssignment =
              WorkOrderStatusConstants.ReadyForAssignment;
            public const string PendingPayment =
              WorkOrderStatusConstants.PendingPayment;
            public const string Assigned = WorkOrderStatusConstants.Assigned;
            public const string Completed = WorkOrderStatusConstants.Completed;
            public const string Paid = WorkOrderStatusConstants.Paid;

            public class onHold : PX.Data.BQL.BqlString.Constant<onHold>
            {
                public onHold() : base(OnHold) { }
            }

            public class readyForAssignment :
              PX.Data.BQL.BqlString.Constant<readyForAssignment>
            {
                public readyForAssignment() : base(ReadyForAssignment) { }
            }

            public class pendingPayment :
              PX.Data.BQL.BqlString.Constant<pendingPayment>
            {
                public pendingPayment() : base(PendingPayment) { }
            }

            public class assigned : PX.Data.BQL.BqlString.Constant<assigned>
            {
                public assigned() : base(Assigned) { }
            }

            public class completed : PX.Data.BQL.BqlString.Constant<completed>
            {
                public completed() : base(Completed) { }
            }

            public class paid : PX.Data.BQL.BqlString.Constant<paid>
            {
                public paid() : base(Paid) { }
            }
        }
        #endregion

        ////////// The added code
        public override void Configure(PXScreenConfiguration config)
        {
            var context = config.GetScreenConfigurationContext<RSSVWorkOrderEntry,
                RSSVWorkOrder>();
            context.AddScreenConfigurationFor(screen => screen
                .StateIdentifierIs<RSSVWorkOrder.status>()
                .AddDefaultFlow(flow => ...));
        }
		////////// The end of added code
    }
}