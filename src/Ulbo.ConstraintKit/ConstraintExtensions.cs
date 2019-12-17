using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace Ulbo.ConstraintKit
{
    public static class ConstraintExtensions
    {
        public static IEnumerable<NSLayoutConstraint> MakeConstraints(this UIView view, params NSLayoutConstraint[] constraints)
        {
            view.TranslatesAutoresizingMaskIntoConstraints = false;
            return constraints.Activate();
        }

        public static IEnumerable<NSLayoutConstraint> MakeConstraints(this UIView view, in Action<ConstraintBuilder> action)
        {
            view.TranslatesAutoresizingMaskIntoConstraints = false;
            var builder = new ConstraintBuilder(view);
            action(builder);
            return builder.Build().Activate();
        }

        public static IEnumerable<NSLayoutConstraint> Priority(this IEnumerable<NSLayoutConstraint> constraints, in UILayoutPriority priority)
        {
            foreach (var constraint in constraints)
            {
                constraint.Priority = (float)priority;
            }

            return constraints;
        }

        public static NSLayoutConstraint Priority(this NSLayoutConstraint constraint, in UILayoutPriority priority)
        {
            constraint.Priority = (float)priority;
            return constraint;
        }

        public static IEnumerable<NSLayoutConstraint> Activate(this IEnumerable<NSLayoutConstraint> constraints)
        {
            NSLayoutConstraint.ActivateConstraints(constraints.ToArray());
            return constraints;
        }

        public static IEnumerable<NSLayoutConstraint> Deactivate(this IEnumerable<NSLayoutConstraint> constraints)
        {
            NSLayoutConstraint.DeactivateConstraints(constraints.ToArray());
            return constraints;
        }

        public static NSLayoutConstraint Activate(this NSLayoutConstraint constraint)
        {
            constraint.Active = true;
            return constraint;
        }

        public static NSLayoutConstraint Deactivate(this NSLayoutConstraint constraint)
        {
            constraint.Active = false;
            return constraint;
        }
    }
}
