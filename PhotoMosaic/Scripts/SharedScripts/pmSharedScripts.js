// --- classes for modeling the world ---
function ClientViewData() {
    this.ClientSize = new Size(-1, -1);
    this.ThumbLayoutSize = new Size(-1, -1);
    this.ThumbCountSize = new Size(0, 0);
    this.ThumbCount = 0;

    this.ThumbSize = new Size(130, 130);

    this.ClientMargin = 15;
    this.ThumbMargin = 1;
    this.GroupLabelHeight = 18;

    if (typeof (window.innerWidth) == 'number') {
        //Non-IE
        this.ClientSize.Width = window.innerWidth;
        this.ClientSize.Height = window.innerHeight;
    } else if (document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight)) {
        //IE 6+ in 'standards compliant mode'
        this.ClientSize.Width = document.documentElement.clientWidth;
        this.ClientSize.Height = document.documentElement.clientHeight;
    } else if (document.body && (document.body.clientWidth || document.body.clientHeight)) {
        //IE 4 compatible
        this.ClientSize.Width = document.body.clientWidth;
        this.ClientSize.Height = document.body.clientHeight;
    }

    //if (this.ClientSize.Width < 400) {
    //    this.ClientSize.Height = Math.max(this.ClientSize.Height, 800); // for small devices, make the page scroll vertically --
    //}

    this.ThumbLayoutSize = new Size(this.ClientSize.Width - (2 * this.ClientMargin), this.ClientSize.Height - (2 * this.ClientMargin));

    if (this.ClientSize.Width <= 300) {
        this.ThumbSize = new Size(60, 60);
    }

    // -- Calc Picutres Across ----
    this.ThumbCountSize.Width = Math.floor((this.ThumbLayoutSize.Width) / ((this.ThumbSize.Width + (2 * this.ThumbMargin))));

    // -- there is extra space, let's use it ---
    var extraWidth = this.ThumbLayoutSize.Width - ((this.ThumbSize.Width + (2 * this.ThumbMargin)) * this.ThumbCountSize.Width);
    var extraWidthPerImage = Math.floor(extraWidth / this.ThumbCountSize.Width);
    /// ????  ---extraWidthPerImage = Math.floor(extraWidthPerImage / 5.0) * 5.0;

    this.ThumbSize.Width += extraWidthPerImage;
    this.ThumbSize.Height += extraWidthPerImage;

    this.ThumbLayoutSize.Width = this.ThumbCountSize.Width * (this.ThumbSize.Width + 2);
    this.ThumbCountSize.Height = Math.floor((this.ThumbLayoutSize.Height * 1.7) / ((this.ThumbSize.Height + (2 * this.ThumbMargin)) ));

    // -- Calc Number of Pictures ----
    this.ThumbCount = this.ThumbCountSize.Height * this.ThumbCountSize.Width;
}

function debouncerUtility(func, timeout) {
    var timeoutID, timeout = timeout || 200;
    return function() {
        var scope = this, args = arguments;
        clearTimeout(timeoutID);
        timeoutID = setTimeout(function() {
            func.apply(scope, Array.prototype.slice.call(args));
        }, timeout);
    };
}

function Size(width, height) {
    this.Width = width;
    this.Height = height;
}

