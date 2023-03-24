namespace BuildCompany;

public interface IBuilder<out TOut, in TIn>
    where TOut : class
    where TIn : class
{
    TOut Build(TIn parameter);
}