using MarsRoverBlazor.Shared;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MarsRoverBlazor.Client.Pages {
    public partial class Index {
        private static int rows = 5;
        private static int cols = 5;

        private bool isTaskRunning = false;
        private bool[,] imgVisible = new bool[rows + 1, cols + 1];
        private string[,] imgRotationArr = new string[rows + 1, cols + 1];
        private Directive[] movePath;
        private string directiveInput;
        private string fileInput;
        private List<string> fileInputList;
        private IBrowserFile f;

        public async void onSubmit() {
            isTaskRunning = true;
            fileInputList = new();

            using (var reader = new StreamReader(f.OpenReadStream())) {

                string line;
                while ((line = await reader.ReadLineAsync()) is not null) {
                    fileInput += line + "\n";
                    fileInputList.Add(line);
                    await StartRoverExpedition(line);
                }
            }
            isTaskRunning = false;
        }

        public void loadFiles(InputFileChangeEventArgs e) {
            f = e.GetMultipleFiles().FirstOrDefault();
        }

        public async Task StartRoverExpedition(string input) {
            isTaskRunning = true;
            clearMars();

            movePath = await Http.GetFromJsonAsync<Directive[]>($"Home?directives={input}");
            for (var i = 0; i < movePath.Length; i++) {
                var item = movePath[i];
                imgVisible[item.y, item.x] = true;
                imgRotationArr[item.y, item.x] = "imgRotation" + item.direction;
                StateHasChanged();
                await Task.Delay(700);
                if (i != movePath.Length - 1) {
                    imgVisible[item.y, item.x] = false;
                }
            }
            isTaskRunning = false;
        }

        private void clearMars() {
            for (int i = 0; i < imgVisible.GetLength(0); i++) {
                for (int j = 0; j < imgVisible.GetLength(1); j++) {
                    imgVisible[i, j] = false;
                }
            }
        }

    }
}
