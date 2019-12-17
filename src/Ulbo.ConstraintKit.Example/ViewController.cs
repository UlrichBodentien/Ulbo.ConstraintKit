using Foundation;
using System;
using UIKit;

namespace Ulbo.ConstraintKit.Example
{
    public class ViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.Red;

            var blueView = new UIView();
            blueView.BackgroundColor = UIColor.Blue;
            View.AddSubview(blueView);

            blueView.MakeConstraints((builder) => builder.AllEdges(View));

            blueView.MakeConstraints(
                blueView.LeftAnchor.ConstraintEqualTo(View.LeftAnchor));
        }
    }
}