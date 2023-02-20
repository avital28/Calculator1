namespace Calculator1;

public partial class MainPage : ContentPage
{
    int count = 0;
    List<double> nums1 = new List<double>();
    List<double> nums2 = new List<double>();
    List<char> operators1 = new List<char>();
    List<char> operators2 = new List<char>();
    string result = "";
    double res;


    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        Button b = (Button)(sender);
        result += b.Text;
        lbl.Text += result;
    }

    private int TextToNum(string b)
    {
        int a;
        a = int.Parse(b);
        count++;
        result = "";
        return a;
    }

    private void OnActionsClicked(object sender, EventArgs e)
    {
        nums1.Add(TextToNum(result));
        Button b = (Button)(sender);
        operators1.Add(char.Parse(b.Text));
        lbl.Text += b.Text;
    }

    private void OnEqualClicked(object sender, EventArgs e)
    {
        nums1.Add(TextToNum(result));
        if (count > 1)
        {
            for (int i = 0; i < operators1.Count; i++)
            {
                operators2.Add(operators1[i]);
            }
            for (int i = 0; i < nums1.Count; i++)
            {
                nums2.Add(nums1[i]);
            }
            lbl.Text += "=";
            int current = 0;
            int length = operators1.Count;
            for (int i = 0; i < length; i++)
            {
                if (operators1[i] == 'x')
                {
                    res = nums1[i] * nums1[i + 1];
                    nums1[i] = 0;
                    nums1[i + 1] = res;
                    if (i + 1 >= nums2.Count)
                    {
                        nums2[i - 1] = res;
                        nums2.RemoveAt(i);
                        
                    }


                    else
                    {
                        nums2[i + 1] = 0;
                        nums2[i] = res;
                        
                    }
                    if (i < operators2.Count)
                        operators2[i] = '^';
                    
                    current = i+1;
                }

                else if (operators1[i] == '/')
                {
                    res = nums1[i] / nums1[i + 1];
                    nums1[i] = 0;
                    nums1[i + 1] = res;
                    if (i + 1 >= nums2.Count)
                    {
                        nums2[i - 1] = res;
                        nums2.RemoveAt(i);

                    }


                    else
                    {
                        nums2[i + 1] = 0;
                        nums2[i] = res;

                    }
                    if (i < operators2.Count)
                        operators2[i] = '^';

                    current = i + 1;
                }
            }
            
            for (int i = 0; i < nums2.Count; i++)
            {
                if (nums2[i]==0)
                    nums2.RemoveAt(i);
            }

            for (int i = 0; i < operators2.Count; i++)
            {
                if (operators2[i] == '^')
                    operators2.RemoveAt(i);
            }
            for (int i = 0; i < operators2.Count; i++)
            {
                if (operators2[i] == '+')
                {
                    res = nums2[i] + nums2[i+1];
                    nums2[i + 1] = res;
                }

                else if (operators2[i] == '-')
                {
                    res = nums2[i] - nums2[i + 1];
                    nums2[i + 1] = res;
                }
            }
           // if (operators[operators.Count - 1] == '+')
           //     res += nums[operators.Count];
           // else if (operators[operators.Count - 1] == '-')
              //  res -= nums[operators.Count];

            lbl.Text += res;
        }
    }
}

