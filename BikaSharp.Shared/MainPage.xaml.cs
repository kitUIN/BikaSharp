using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Uno.Extensions;
using Microsoft.Extensions.Logging;
using Serilog;
using Windows.Storage;
using System.Diagnostics;
using muxc = Microsoft.UI.Xaml.Controls;
using Windows.Devices.Enumeration;
using bikabika.API.Response;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BikaSharp
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }


        private void TabView_AddTabButtonClick(muxc.TabView sender, object args)
        {
            var newTab = new muxc.TabViewItem();
            newTab.IconSource = new muxc.SymbolIconSource() { Symbol = Symbol.Document };
            newTab.Header = "New Document";

            // The Content of a TabViewItem is often a frame which hosts a page.
            Frame frame = new Frame();
            newTab.Content = frame;

            sender.TabItems.Add(newTab);
            string myJsonResponse =
                @"{
    ""code"": 200,
    ""message"": ""success"",
    ""data"": {
        ""categories"": [
            {
                ""title"": ""Ԯ������"",
                ""thumb"": {
                    ""originalName"": ""help.jpg"",
                    ""path"": ""help.jpg"",
                    ""fileServer"": ""https://diwodiwo.xyz/static/""
                },
                ""isWeb"": true,
                ""active"": true,
                ""link"": ""https://donate.bidobido.xyz""
            },
            {
                ""title"": ""����С�Y��"",
                ""thumb"": {
                    ""originalName"": ""picacomic-gift.jpg"",
                    ""path"": ""picacomic-gift.jpg"",
                    ""fileServer"": ""https://diwodiwo.xyz/static/""
                },
                ""isWeb"": true,
                ""link"": ""https://gift-web.bidobido.xyz"",
                ""active"": true
            },
            {
                ""title"": ""С�Ӱ"",
                ""thumb"": {
                    ""originalName"": ""av.jpg"",
                    ""path"": ""av.jpg"",
                    ""fileServer"": ""https://diwodiwo.xyz/static/""
                },
                ""isWeb"": true,
                ""link"": ""https://adult-movie.bidobido.xyz"",
                ""active"": true
            },
            {
                ""title"": ""С�﷬"",
                ""thumb"": {
                    ""originalName"": ""h.jpg"",
                    ""path"": ""h.jpg"",
                    ""fileServer"": ""https://diwodiwo.xyz/static/""
                },
                ""isWeb"": true,
                ""link"": ""https://adult-animate.bidobido.xyz"",
                ""active"": true
            },
            {
                ""title"": ""���Ǯ���"",
                ""thumb"": {
                    ""originalName"": ""picacomic-paint.jpg"",
                    ""path"": ""picacomic-paint.jpg"",
                    ""fileServer"": ""https://diwodiwo.xyz/static/""
                },
                ""isWeb"": true,
                ""link"": ""https://paint-web.bidobido.xyz"",
                ""active"": true
            },
            {
                ""title"": ""�����̵�"",
                ""thumb"": {
                    ""originalName"": ""picacomic-shop.jpg"",
                    ""path"": ""picacomic-shop.jpg"",
                    ""fileServer"": ""https://diwodiwo.xyz/static/""
                },
                ""isWeb"": true,
                ""link"": ""https://online-shop-web.bidobido.xyz"",
                ""active"": true
            },
            {
                ""title"": ""��Ҷ��ڿ�"",
                ""thumb"": {
                    ""originalName"": ""every-see.jpg"",
                    ""path"": ""every-see.jpg"",
                    ""fileServer"": ""https://diwodiwo.xyz/static/""
                },
                ""isWeb"": false,
                ""active"": true
            },
            {
                ""title"": ""."",
                ""thumb"": {
                    ""originalName"": ""recommendation.jpg"",
                    ""path"": ""tobs/04d05dd9-c8c1-4c4d-8b56-231a59b0add8.jpg"",
                    ""fileServer"": ""https://storage-b.picacomic.com""
                },
                ""isWeb"": false,
                ""active"": true
            },
            {
                ""title"": ""�������"",
                ""thumb"": {
                    ""originalName"": ""old.jpg"",
                    ""path"": ""old.jpg"",
                    ""fileServer"": ""https://diwodiwo.xyz/static/""
                },
                ""isWeb"": false,
                ""active"": true
            },
            {
                ""title"": ""�ٷ����ڿ�"",
                ""thumb"": {
                    ""originalName"": ""promo.jpg"",
                    ""path"": ""promo.jpg"",
                    ""fileServer"": ""https://diwodiwo.xyz/static/""
                },
                ""isWeb"": false,
                ""active"": true
            },
            {
                ""title"": ""�����\��"",
                ""thumb"": {
                    ""originalName"": ""picacomic-move-cat.jpg"",
                    ""path"": ""picacomic-move-cat.jpg"",
                    ""fileServer"": ""https://diwodiwo.xyz/static/""
                },
                ""isWeb"": true,
                ""active"": true,
                ""link"": ""https://move-web.bidobido.xyz""
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6e9"",
                ""title"": ""���ǝh��"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""translate.png"",
                    ""path"": ""f541d9aa-e4fd-411d-9e76-c912ffc514d1.png"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6d1"",
                ""title"": ""ȫ��"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""ȫ��.jpg"",
                    ""path"": ""8cd41a55-591c-424c-8261-e1d56d8b9425.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6cd"",
                ""title"": ""�Lƪ"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""�Lƪ.jpg"",
                    ""path"": ""681081e7-9694-436a-97e4-898fc68a8f89.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6ca"",
                ""title"": ""ͬ��"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""ͬ��.jpg"",
                    ""path"": ""1a33f1be-90fa-4ac7-86d7-802da315732e.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6ce"",
                ""title"": ""��ƪ"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""��ƪ.jpg"",
                    ""path"": ""bd021022-8e19-49ff-8c62-6b29f31996f9.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""584ea1f45a44ac4f7dce3623"",
                ""title"": ""�A���I��"",
                ""description"": ""ħ����ŮС�A�����}�ı���"",
                ""thumb"": {
                    ""originalName"": ""cat_cirle.jpg"",
                    ""path"": ""c7e86b6e-4d27-4d81-a083-4a774ceadf72.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""58542b601b8ef1eb33b57959"",
                ""title"": ""���{����"",
                ""description"": ""���{����ı���"",
                ""thumb"": {
                    ""originalName"": ""blue.jpg"",
                    ""path"": ""b8608481-6ec8-46a3-ad63-2f8dc5da4523.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6e5"",
                ""title"": ""CG�s�D"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""CG�s�D.jpg"",
                    ""path"": ""b62b79b7-26af-4f81-95bf-d27ef33d60f3.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6e8"",
                ""title"": ""Ӣ�Z ENG"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""Ӣ�Z ENG.jpg"",
                    ""path"": ""6621ae19-a792-4d0c-b480-ae3496a95de6.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6e0"",
                ""title"": ""����"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""����.jpg"",
                    ""path"": ""c90a596c-4f63-4bdf-953d-392edcbb4889.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6de"",
                ""title"": ""����"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""����.jpg"",
                    ""path"": ""18fde59b-bee5-4177-bf1f-88c87c7c9d70.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6d2"",
                ""title"": ""�ٺϻ��@"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""�ٺϻ��@.jpg"",
                    ""path"": ""de5f1ca3-840a-4ea4-b6c0-882f1d80bd2e.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6e2"",
                ""title"": ""�������@"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""1492872524635.jpg"",
                    ""path"": ""dcfa0115-80c9-4233-97e3-1ad469c2c0df.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6e4"",
                ""title"": ""�����܌W"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""�����܌W.jpg"",
                    ""path"": ""39119d6c-4808-4859-98df-4dda30b9da3b.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6d3"",
                ""title"": ""��m�W��"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""��m�W��.jpg"",
                    ""path"": ""dec122af-84bf-4736-b8f0-d6533a2839f7.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6d4"",
                ""title"": ""�������@"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""�������@.jpg"",
                    ""path"": ""73d8a102-1805-4b14-b258-a95c85b02b8a.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5abb3fd683111d2ad3eecfca"",
                ""title"": ""���б�"",
                ""thumb"": {
                    ""originalName"": ""Loveland_001 (2).jpg"",
                    ""path"": ""a29c241a-2af7-47f2-aae5-b640374b12ac.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6da"",
                ""title"": ""���ϵ"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""���ϵ.jpg"",
                    ""path"": ""91e551c5-a98f-4f41-b7a0-c125bd77c523.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6db"",
                ""title"": ""����ϵ"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""����ϵ.jpg"",
                    ""path"": ""098f612c-9d16-4848-9732-0305b66ed799.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6cb"",
                ""title"": ""SM"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""SM.jpg"",
                    ""path"": ""41fc9bce-68f6-4b36-98cf-14ab3d3bd19e.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6d0"",
                ""title"": ""���D�Q"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""���D�Q.jpg"",
                    ""path"": ""f5c70a00-538c-44b8-b692-d6c3b049e133.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6df"",
                ""title"": ""�����"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""�����.jpg"",
                    ""path"": ""ad3373c7-4974-45f5-b5d6-eb9490363314.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6cc"",
                ""title"": ""����"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""����.jpg"",
                    ""path"": ""e3359724-603b-47d8-905f-c88c5d38c983.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6d8"",
                ""title"": ""NTR"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""NTR.jpg"",
                    ""path"": ""e10cf018-e214-41fa-bf1c-376a6b7a24ea.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6d9"",
                ""title"": ""����"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""����.jpg"",
                    ""path"": ""4c3a9fb0-3084-4abf-bbc9-8efa33554749.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6d6"",
                ""title"": ""�����"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""�����.jpg"",
                    ""path"": ""b09840fe-8ca9-41ac-9e73-3dd68e426865.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6cf"",
                ""title"": ""Ş��ղ�"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""Ş��ղ�.jpg"",
                    ""path"": ""1ed52b9e-8ac3-47ae-bafc-c31bfab9b3d5.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6d7"",
                ""title"": ""Love Live"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""Love Live.jpg"",
                    ""path"": ""b2ae70d1-1c0e-415f-b3f8-0f6f17626387.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6dc"",
                ""title"": ""SAO ��������"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""SAO ��������.jpg"",
                    ""path"": ""f7c0ccc3-6baf-4823-b2b5-a7a83d426d4c.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6e1"",
                ""title"": ""Fate"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""Fate.jpg"",
                    ""path"": ""44bf46b9-415e-490b-9b61-7916ef2cea53.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6dd"",
                ""title"": ""�|��"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""�|��.jpg"",
                    ""path"": ""c373bf9d-1003-453d-a791-f65dde937654.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""59041d54ccc747074b47dae4"",
                ""title"": ""WEBTOON"",
                ""description"": ""Webtoon ��һ�Nʼ����n�����¸���W·�������ɡ�Web���W·��������Cartoon����������ͨ�����M�ɣ�ֻ�������»��Ӿ�����x�����跭퓣���һ�N������X���Є��b�ö��O��������"",
                ""thumb"": {
                    ""originalName"": ""52a81f09-32a0-422b-bba3-207eb4d22520.jpg"",
                    ""path"": ""60c01af5-e9cd-4888-bf5c-89fb60a97cc7.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6e3"",
                ""title"": ""����Ŀ�"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""����Ŀ�.jpg"",
                    ""path"": ""c4314a3f-2644-473f-9b13-d78c8d857933.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5bd66e7e8ff47f7c46cf999d"",
                ""title"": ""�W��"",
                ""description"": ""�W��"",
                ""thumb"": {
                    ""fileServer"": ""https://storage1.picacomic.com"",
                    ""path"": ""0486b618-ccbb-4c77-a141-06351079eb9f.jpg"",
                    ""originalName"": ""67edd79c63e037afcd6309c25ad312a1.jpg""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6e6"",
                ""title"": ""Cosplay"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""Cosplay.jpg"",
                    ""path"": ""24ee03b1-ad3d-4c6b-9f0f-83cc95365006.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            },
            {
                ""_id"": ""5821859b5f6b9a4f93dbf6d5"",
                ""title"": ""�ؿڵ؎�"",
                ""description"": ""δ֪"",
                ""thumb"": {
                    ""originalName"": ""�ؿڵ؎�.jpg"",
                    ""path"": ""4540db04-ebbe-4834-a77a-7b7995b5f784.jpg"",
                    ""fileServer"": ""https://storage1.picacomic.com""
                }
            }
        ]
    }
}";
            CategoriesResponse cate = JsonSerializer.Deserialize(myJsonResponse, CategoriesResponseContext.Default.CategoriesResponse);

            this.LogDebug(cate.data.categories[0].title);


        }

        // Remove the requested tab from the TabView
        private void TabView_TabCloseRequested(muxc.TabView sender, muxc.TabViewTabCloseRequestedEventArgs args)
        {
            sender.TabItems.Remove(args.Tab);
        }

    }

}
