namespace Calculator1;

public partial class MainPage : ContentPage
{
    int count = 0;
    List<double> nums1 = new List<double>();
    List<double> nums2 = new List<double>();
    List<char> operators1 = new List<char>();
    List<char> operators2 = new List<char>();
    string result = "";
    string equation = "";
    string current = "";
    double res;
    bool BeenDeleted=false;
    bool DividedByZero = false;


    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        Button b = (Button)(sender);
        result = b.Text;
        current += b.Text;
        equation+=b.Text;
        lbl.Text += result;
    }

    private double TextToNum(string b)
    {
        double a;
        a = double.Parse(b);
        count++;
        current = "";
        return a;
    }



    private void OnActionsClicked(object sender, EventArgs e)
    {
        Button b = (Button)(sender);
        if (BeenDeleted == false)
        {
            nums1.Add(TextToNum(current));
        }
        else
            BeenDeleted = false;
        
        operators1.Add(char.Parse(b.Text));
        lbl.Text += b.Text;
        equation+=b.Text;   
    }

    private void OnEqualClicked(object sender, EventArgs e)
    {
        nums1.Add(TextToNum(current));
        for (int i = 0; i < nums1.Count; i++)
        {
            nums2.Add(nums1[i]);
        }
        if (count > 1)
        {
            for (int i = 0; i < operators1.Count; i++)
            {
                operators2.Add(operators1[i]);
            }
            lbl.Text += "=";
            int length = operators1.Count;
            for (int i = 0; i < length; i++)
            {
                if (operators1[i] == 'x')
                {
                    res = nums1[i] * nums1[i + 1];
                    nums1[i] = 0;
                    nums1[i + 1] = res;
                    if (i < operators2.Count)
                        operators2[i] = '^';
                }

                else if (operators1[i] == '/')
                {
                    if (nums1[i + 1] != 0)
                    {
                        res = nums1[i] / nums1[i + 1];
                        nums1[i] = 0;
                        nums1[i + 1] = res;
                        if (i < operators2.Count)
                            operators2[i] = '^';
                    }
                    else
                    {
                        lbl.Text = "Syntax error";
                        DividedByZero = true;
                    }         
                    
                }
            }

            if (DividedByZero == false)
            {
                for (int i = 0; i < nums1.Count; i++)
                {
                    if (nums1[i] == 0 && nums2[i] != 0)
                    {
                        nums1.RemoveAt(i);
                        nums2.RemoveAt(i);
                        i--;
                    }
                }

                for (int i = 0; i < operators2.Count; i++)
                {
                    if (operators2[i] == '^')
                    {
                        operators2.RemoveAt(i);
                        i--;
                    }
                }
                for (int i = 0; i < operators2.Count; i++)
                {
                    if (operators2[i] == '+')
                    {
                        res = nums1[i] + nums1[i + 1];
                        nums1[i + 1] = res;
                    }

                    else if (operators2[i] == '-')
                    {
                        res = nums1[i] - nums1[i + 1];
                        nums1[i + 1] = res;
                    }
                }
                lbl.Text += " " + res;
            }
            else
                DividedByZero = false;



           
        }
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        Button b = sender as Button;
        if (b.Text=="AC")
        {
            lbl.Text = "";
            equation = "";
            res = 0;
            current = "";
            count = 0;
            nums1.Clear();
            nums2.Clear();
            operators1.Clear();
            operators2.Clear();
        }
        else if (b.Text=="DEL")
        {
            if (equation != null)
            {
                char last = equation[equation.Length - 1];
                equation = equation.Remove(equation.Length - 1, 1);
                lbl.Text = equation;
                if (char.IsDigit(last))
                {
                    current = current.Remove(current.Length - 1, 1);
                }
                else
                {
                    operators1.RemoveAt(operators1.Count - 1);
                    BeenDeleted = true;
                }
            }
            else
                lbl.Text = "";
        }
        
        

    }

    private void DotClicked(object sender, EventArgs e)
    {
        current += ".";
        lbl.Text +=".";
    }
}

