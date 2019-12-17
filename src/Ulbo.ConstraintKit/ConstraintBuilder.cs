using System.Collections.Generic;
using UIKit;

namespace Ulbo.ConstraintKit
{
    public class ConstraintBuilder
    {
        private readonly List<NSLayoutConstraint> constraints = new List<NSLayoutConstraint>();
        private readonly UIView view1;

        public ConstraintBuilder(in UIView view1)
        {
            this.view1 = view1;
        }

        public ConstraintBuilder AllEdges(in UIView view2)
        {
            AllEdges(view2, 0);
            return this;
        }

        public ConstraintBuilder AllEdges(in UIView view2, int margin)
        {
            AllEdges(view2, margin, margin, margin, margin);
            return this;
        }

        public ConstraintBuilder AllEdges(in UIView view2, int leftMargin, int topMargin, int rightMargin, int bottomMargin)
        {
            constraints.AddRange(
                view1.MakeConstraints(
                    view1.TopAnchor.ConstraintEqualTo(view2.TopAnchor, topMargin),
                    view1.BottomAnchor.ConstraintEqualTo(view2.BottomAnchor, -bottomMargin),
                    view1.LeadingAnchor.ConstraintEqualTo(view2.LeadingAnchor, leftMargin),
                    view1.TrailingAnchor.ConstraintEqualTo(view2.TrailingAnchor, -rightMargin)));

            return this;
        }

        public NSLayoutConstraint[] Build()
        {
            return constraints.ToArray();
        }
    }
}
