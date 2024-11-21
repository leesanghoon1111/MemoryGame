using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAME14
{
    public partial class GameWindow : Form
    {
     
        Random Location = new Random();
        //게임에서 무작위 위치를 생성하기 위해 Random 클래스의 인스턴스를 생성합니다. 
        //이를 통해 카드의 위치를 무작위로 섞을 때 사용할 수 있습니다.
        List<Point> points =new List<Point>();
        //points는 좌표(x, y 값)를 저장하는 리스트입니다.
        //게임 시작 시 각 카드의 위치를 기록하거나, 섞인 후 위치를 저장하는 데 사용됩니다.
        bool again = false;
        //이 변수는 다시 클릭 가능 여부를 판단하는 데 사용될 것
        //플레이어가 이미 두 장의 카드를 선택한 경우 클릭을 비활성화하는 데 사용될 수 있습니다.
        PictureBox pendingImage1;
        PictureBox pendingImage2;
        //플레이어가 선택한 두 개의 카드(PictureBox 객체)를 임시로 저장하는 데 사용됩니다.
        //두 카드를 비교해서 같은지 확인하거나, 맞지 않으면 원래 상태로 되돌리기 위해 사용됩니다.
        public GameWindow()
        {                   
            InitializeComponent();//여러가지 버튼 초기화
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

            ScoreCounter.Text = "0";//게임시작시  ScoreCounter의 텍스트를 0으로 초기화,게임시작시 점수를 초기화
            label1.Text = "5"; 
            foreach(PictureBox picture in CardsHolder.Controls)
            {

                picture.Enabled= false;
                points.Add(picture.Location);

            }
            //각 PictureBox의 Enabled 속성을 false로 설정해, 초기 상태에서 비활성화합니다.
            //모든 PictureBox의 위치(Location)를 points 리스트에 추가하여 나중에 섞기 위해 저장합니다.
            foreach (PictureBox picture in CardsHolder.Controls)
            {
                int next =Location.Next(points.Count);
                Point p = points[next];
                picture.Location = p;
                points.Remove(p);
            }
            //저장된 points 리스트를 이용해 각 카드의 위치를 무작위로 섞습니다.
            //Location.Next(points.Count)를 사용해 랜덤한 인덱스를 생성합니다.
            //points[next]에서 해당 위치를 가져와 카드의 위치(Location)를 변경합니다.
            //가져온 위치는 points 리스트에서 제거해 중복 사용을 방지합니다.
            timer2.Start();
            timer1.Start();
            //두 개의 타이머(timer1과 timer2)를 시작합니다.
            Card1.Image = Properties.Resources.Card1;
            DupCard1.Image = Properties.Resources.Card1;
            Card2.Image = Properties.Resources.Card2;
            DupCard2.Image = Properties.Resources.Card2;
            Card3.Image = Properties.Resources.Card3;
            DupCard3.Image = Properties.Resources.Card3;
            Card4.Image = Properties.Resources.Card4;
            DupCard4.Image = Properties.Resources.Card4;
            Card5.Image = Properties.Resources.Card5;
            DupCard5.Image = Properties.Resources.Card5;
            Card6.Image = Properties.Resources.Card6;
            DupCard6.Image = Properties.Resources.Card6;
            Card7.Image = Properties.Resources.Card7;
            DupCard7.Image = Properties.Resources.Card7;
            Card8.Image = Properties.Resources.Card8;
            DupCard8.Image = Properties.Resources.Card8;
            Card9.Image = Properties.Resources.Card9;
            DupCard9.Image = Properties.Resources.Card9;
            Card10.Image = Properties.Resources.Card10;
            DupCard10.Image = Properties.Resources.Card10;
            Card11.Image = Properties.Resources.Card11;
            DupCard11.Image = Properties.Resources.Card11;
            Card12.Image = Properties.Resources.Card12;
            DupCard12.Image = Properties.Resources.Card12;

            //Properties.Resources를 통해 프로젝트 리소스에 저장된 이미지 파일을 참조합니다.
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();//timer1은 한 번만 실행되는 초기화 타이머로 보이며, 더 이상 실행되지 않도록 중지합니다.
            foreach (PictureBox picture in CardsHolder.Controls)//CardsHolder에 있는 모든 PictureBox(카드 컨트롤)를 순회하며 각 카드에 대해 아래 작업을 수행합니다
            {
                picture.Enabled = true;//모든 카드를 활성화하여 클릭 가능하게 만듭니다.
                picture.Cursor = Cursors.Hand;//마우스를 카드 위에 올렸을 때 커서가 손 모양으로 표시되도록 설정합니다.
                picture.Image = Properties.Resources.Cover;//각 카드의 이미지를 "뒷면"으로 설정하여 숨깁니다.

            }
        }

        private void timer2_Tick(object sender, EventArgs e)//제한 시간을 관리합니다. 시간이 다 되면 타이머를 멈춥니다.
                                                            //label1에 남은 시간을 실시간으로 업데이트하여 화면에 표시합니다.

        {
            int timer = Convert.ToInt32(label1.Text);//label1에 표시된 텍스트 값을 정수로 변환하여 timer 변수에 저장합니다.
            //이 변수는 남은 시간을 나타냅니다.
            timer = timer - 1;//timer 값을 1초 감소시킵니다.
            label1.Text = Convert.ToString(timer);//감소된 시간을 다시 label1에 업데이트하여 화면에 표시합니다.
            if (timer == 0)
            {
                timer2.Stop();//타이머를 멈춥니다.
                //더 이상 시간이 감소하지 않도록 설정합니다.
            }
        }
        //chnage
        #region Cards
        private void Card1_Click(object sender, EventArgs e)//카드 Card1 클릭 시 동작을 정의합니다. 카드의 이미지를 보여주고, 선택한 카드의 정보를 관리합니다.
        {
            Card1.Image = Properties.Resources.Card1;//Card1의 이미지를 카드의 앞면(지정된 이미지)으로 설정합니다.
            if (pendingImage1 == null)
                {
                pendingImage1 = Card1;//첫번째 선택이 비어있으면 Card1을 pendingImage1에 저장합니다.
            }
            else if(pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card1;//첫 번째 선택이 존재하고, 두 번째 선택이 비어 있으면 Card1을 pendingImage2에 저장합니다.
            }
            if(pendingImage1 != null &&pendingImage2 != null)//두 장의 카드가 선택된 경우:
            {
                if(pendingImage1.Tag == pendingImage2.Tag)//두 카드의 Tag 속성이 같으면
                {
                    pendingImage1 = null;//선택된 두카드를 초기화
                    pendingImage2 = null;//선택된 두카드를 초기화
                    Card1.Enabled = false;//해당 카드와 짝 카드의 클릭을 비활성화합니다.

                    DupCard1.Enabled = false;//해당 카드와 짝 카드의 클릭을 비활성화합니다.

                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);//점수증가
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);//점수감소
                    timer3.Start();//timer3를 시작하여 일정 시간 뒤 두 카드를 다시 "뒤집는" 작업을 수행합니다.
                }
              
            }
        }

        private void DupCard1_Click(object sender, EventArgs e)
        {
            DupCard1.Image = Properties.Resources.Card1;//DupCard1의 이미지를 카드의 앞면(지정된 이미지)으로 설정합니다.
            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard1;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard1;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card1.Enabled = false;
                    DupCard1.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
               
            }
        }

        private void Card2_Click(object sender, EventArgs e)
        {
            Card2.Image = Properties.Resources.Card2;
           
            if (pendingImage1 == null)
            {
                pendingImage1 = Card2;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card2;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card2.Enabled = false;
                    DupCard2.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }
               
            }
        }

        private void DupCard2_Click(object sender, EventArgs e)
        {
            DupCard2.Image = Properties.Resources.Card2;
          
            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard2;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard2;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card2.Enabled = false;
                    DupCard2.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) -10);
                    timer3.Start();
                }
               
            }
        }

        private void Card3_Click(object sender, EventArgs e)
        {
            Card3.Image = Properties.Resources.Card3;
            if (pendingImage1 == null)
            {
                pendingImage1 = Card3;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card3;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card3.Enabled = false;
                    DupCard3.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void DupCard3_Click(object sender, EventArgs e)
        {
            DupCard3.Image = Properties.Resources.Card3;
            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard3;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard3;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card3.Enabled = false;
                    DupCard3.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void Card4_Click(object sender, EventArgs e)
        {
            Card4.Image = Properties.Resources.Card4;
            if (pendingImage1 == null)
            {
                pendingImage1 = Card4;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card4;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card4.Enabled = false;
                    DupCard4.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }

        }

        private void DupCard4_Click(object sender, EventArgs e)
        {
            DupCard4.Image = Properties.Resources.Card4;
            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard4;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard4;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card4.Enabled = false;
                    DupCard4.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void Card5_Click(object sender, EventArgs e)
        {
            Card5.Image = Properties.Resources.Card5;
            if (pendingImage1 == null)
            {
                pendingImage1 = Card5;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card5;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card5.Enabled = false;
                    DupCard5.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void DupCard5_Click(object sender, EventArgs e)
        {
            DupCard5.Image = Properties.Resources.Card5;
            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard5;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard5;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card5.Enabled = false;
                    DupCard5.Enabled = false;
                      ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) -10);
                    timer3.Start();
                }

            }
        }

        private void Card6_Click(object sender, EventArgs e)
        {
            Card6.Image = Properties.Resources.Card6;
            if (pendingImage1 == null)
            {
                pendingImage1 = Card6;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card6;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card6.Enabled = false;
                    DupCard6.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void DupCard6_Click(object sender, EventArgs e)
        {
            DupCard6.Image = Properties.Resources.Card6;
            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard6;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard6;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card6.Enabled = false;
                    DupCard6.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void Card7_Click(object sender, EventArgs e)
        {
            Card7.Image = Properties.Resources.Card7;
            if (pendingImage1 == null)
            {
                pendingImage1 = Card7;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card7;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card7.Enabled = false;
                    DupCard7.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void DupCard7_Click(object sender, EventArgs e)
        {
            DupCard7.Image = Properties.Resources.Card7;
            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard7;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard7;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card7.Enabled = false;
                    DupCard7.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void Card8_Click(object sender, EventArgs e)
        {
            Card8.Image = Properties.Resources.Card8;
            if (pendingImage1 == null)
            {
                pendingImage1 = Card8;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card8;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card8.Enabled = false;
                    DupCard8.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void DupCard8_Click(object sender, EventArgs e)
        {
            DupCard8.Image = Properties.Resources.Card8;
            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard8;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard8;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card8.Enabled = false;
                    DupCard8.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void Card9_Click(object sender, EventArgs e)
        {
            Card9.Image = Properties.Resources.Card9;
            if (pendingImage1 == null)
            {
                pendingImage1 = Card9;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card9;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card9.Enabled = false;
                    DupCard9.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void DupCard9_Click(object sender, EventArgs e)
        {
            DupCard9.Image = Properties.Resources.Card9;
            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard9;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard9;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card9.Enabled = false;
                    DupCard9.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void Card10_Click(object sender, EventArgs e)
        {
            Card10.Image = Properties.Resources.Card10;
            if (pendingImage1 == null)
            {
                pendingImage1 = Card10;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card10;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card10.Enabled = false;
                    DupCard10.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void DupCard10_Click(object sender, EventArgs e)
        {
            DupCard10.Image = Properties.Resources.Card10;
            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard10;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard10;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card10.Enabled = false;
                    DupCard10.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void Card11_Click(object sender, EventArgs e)
        {
            Card11.Image = Properties.Resources.Card11;
            if (pendingImage1 == null)
            {
                pendingImage1 = Card11;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card11;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card11.Enabled = false;
                    DupCard11.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void DupCard11_Click(object sender, EventArgs e)
        {
            DupCard11.Image = Properties.Resources.Card11;
            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard11;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard11;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card11.Enabled = false;
                    DupCard11.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void Card12_Click(object sender, EventArgs e)
        {
            Card12.Image = Properties.Resources.Card12;
            if (pendingImage1 == null)
            {
                pendingImage1 = Card12;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = Card12;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card12.Enabled = false;
                    DupCard12.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }

        private void DupCard12_Click(object sender, EventArgs e)
        {
            DupCard12.Image = Properties.Resources.Card12;
            if (pendingImage1 == null)
            {
                pendingImage1 = DupCard12;
            }
            else if (pendingImage1 != null && pendingImage2 == null)
            {
                pendingImage2 = DupCard12;
            }
            if (pendingImage1 != null && pendingImage2 != null)
            {
                if (pendingImage1.Tag == pendingImage2.Tag)
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    Card12.Enabled = false;
                    DupCard12.Enabled = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 10);
                    timer3.Start();
                }

            }
        }
        #endregion

        private void timer3_Tick(object sender, EventArgs e)// 목적 잘못된 카드 선택 시, 선택된 두 장의 카드를 다시 뒤집어 원래 상태로 되돌립니다.
                                                            //선택된 두 카드를 초기화하여 다음 비교가 가능하도록 준비합니다.
        {
            timer3.Stop();
            //타이머를 멈춥니다.
            //timer3는 카드 두 장을 선택했을 때 일정 시간(예: 1초)을 기다렸다가 실행됩니다.
            pendingImage1.Image = Properties.Resources.Cover;//첫 번째 선택된 카드의 이미지를 "뒷면" 이미지(Cover)로 되돌립니다.
            pendingImage2.Image = Properties.Resources.Cover;//두 번째 선택된 카드의 이미지를 "뒷면"으로 되돌립니다.
            pendingImage1 = null;//선택된 카드 참조를 초기화합니다.
            pendingImage2 = null;//이를 통해 다음 선택 시 새로운 카드를 저장할 수 있도록 준비합니다.

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop(); // 기존 타이머 정지
            timer1.Interval = 5000; // 타이머 간격을 5초로 재설정 (이미 설정되어 있다면 생략 가능)
            GameWindow_Load(sender, e); // 게임 초기화
            timer1.Start(); // 타이머 시작
        }
    }
}
