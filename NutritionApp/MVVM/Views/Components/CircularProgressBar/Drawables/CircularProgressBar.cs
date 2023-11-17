using System.ComponentModel;

namespace NutritionApp.MVVM.Views.Components.CircularProgressBar.Drawables;

public class CircularProgressBarDrawable : BindableObject, IDrawable, INotifyPropertyChanged
{
    public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(double), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(int), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(int), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty ProgressLeftColorProperty = BindableProperty.Create(nameof(ProgressLeftColor), typeof(Color), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(string));

    public double Progress
    {
        get => (double)GetValue(ProgressProperty);
        set => SetValue(ProgressProperty, value);
    }

    public int Size
    {
        get { return (int)GetValue(SizeProperty); }
        set { SetValue(SizeProperty, value); }
    }

    public int Thickness
    {
        get { return (int)GetValue(ThicknessProperty); }
        set { SetValue(ThicknessProperty, value); }
    }

    public Color ProgressColor
    {
        get { return (Color)GetValue(ProgressColorProperty); }
        set { SetValue(ProgressColorProperty, value); }
    }

    public Color ProgressLeftColor
    {
        get { return (Color)GetValue(ProgressLeftColorProperty); }
        set { SetValue(ProgressLeftColorProperty, value); }
    }

    public Color TextColor
    {
        get { return (Color)GetValue(TextColorProperty); }
        set { SetValue(TextColorProperty, value); }
    }

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        float effectiveSize = Size - Thickness;
        float x = Thickness / 2;
        float y = Thickness / 2;

        if (Progress < 0)
        {
            Progress = 0;
        }
        else if (Progress > 1)
        {
            Progress = 1;
        }

        if (Progress < 1)
        {
            float angle = CircularProgressBarDrawable.GetAngle(Progress);

            canvas.StrokeColor = ProgressLeftColor;
            canvas.StrokeSize = Thickness;
            canvas.DrawEllipse(x, y, effectiveSize, effectiveSize);

            canvas.StrokeColor = ProgressColor;
            canvas.StrokeSize = Thickness;
            canvas.DrawArc(x, y, effectiveSize, effectiveSize, 90, angle, true, false);
        }
        else
        {
            canvas.StrokeColor = ProgressColor;
            canvas.StrokeSize = Thickness;
            canvas.DrawEllipse(x, y, effectiveSize, effectiveSize);
        }

        float fontSize = effectiveSize / 6f;
        canvas.FontSize = fontSize;
        canvas.FontColor = TextColor;

        float verticalPosition = (Size / 2 - fontSize / 2) * 0.9f;
        canvas.DrawString($"{Text}", x, verticalPosition, effectiveSize, effectiveSize / 4, HorizontalAlignment.Center, VerticalAlignment.Center);
    }

    private static float GetAngle(double progress)
    {
        float factor = 90f / 25f;

        if (progress > 0.75f)
        {
            return (float)(-180 - (progress - 0.75f) * factor);
        }
        else if (progress > 0.50)
        {
            return (float)(-90 - (progress - 0.50f) * factor);
        }
        else if (progress > 0.25)
        {
            return (float)(0 - (progress - 0.25) * factor);
        }
        else
        {
            return (float)(90 - progress * factor);
        }
    }
}