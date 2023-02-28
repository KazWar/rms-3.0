namespace RMS.Web.Api.V2.Utilities
{
    public class RuleParser
    {
        public string Parse(Rule rule)
        {
            return (rule.Error == null) ? 
                string.Format(rule.Expression, rule.Conditions) :
                string.Format(rule.Expression + " || " + rule.Error, rule.Conditions);
        }
    }
}
