#pragma once

namespace TFG__1_C__ {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace std;

	/// <summary>
	/// Resumen de MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: agregar código de constructor aquí
			//
		}

	protected:
		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^ label1;
	protected:
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::Label^ label4;
	private: System::Windows::Forms::Label^ label5;
	private: System::Windows::Forms::TextBox^ txtDivisaInicial;
	private: System::Windows::Forms::TextBox^ txtDivisaFinal;
	private: System::Windows::Forms::TextBox^ txtImportSelecionat;

	private: System::Windows::Forms::TextBox^ txtcambi;
	private: System::Windows::Forms::TextBox^ txtImportCalculat;





	private: System::Windows::Forms::Button^ btnNovaConsulta;
	private: System::Windows::Forms::Button^ btnGuardarValors;



	private:
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		void InitializeComponent(void)
		{
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->txtDivisaInicial = (gcnew System::Windows::Forms::TextBox());
			this->txtDivisaFinal = (gcnew System::Windows::Forms::TextBox());
			this->txtImportSelecionat = (gcnew System::Windows::Forms::TextBox());
			this->txtcambi = (gcnew System::Windows::Forms::TextBox());
			this->txtImportCalculat = (gcnew System::Windows::Forms::TextBox());
			this->btnNovaConsulta = (gcnew System::Windows::Forms::Button());
			this->btnGuardarValors = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Segoe UI", 9));
			this->label1->Location = System::Drawing::Point(42, 30);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(95, 20);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Divisa inicial:";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Segoe UI", 9));
			this->label2->Location = System::Drawing::Point(42, 84);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(85, 20);
			this->label2->TabIndex = 1;
			this->label2->Text = L"Divisa final:";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Font = (gcnew System::Drawing::Font(L"Segoe UI", 9));
			this->label3->Location = System::Drawing::Point(42, 143);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(135, 20);
			this->label3->TabIndex = 2;
			this->label3->Text = L"Import seleccionat:";
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Font = (gcnew System::Drawing::Font(L"Segoe UI", 9));
			this->label4->Location = System::Drawing::Point(42, 201);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(99, 20);
			this->label4->TabIndex = 3;
			this->label4->Text = L"Cambi actual:";
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Font = (gcnew System::Drawing::Font(L"Segoe UI", 9));
			this->label5->Location = System::Drawing::Point(42, 253);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(112, 20);
			this->label5->TabIndex = 4;
			this->label5->Text = L"Import calculat:";
			this->label5->Click += gcnew System::EventHandler(this, &MyForm::label5_Click);
			// 
			// txtDivisaInicial
			// 
			this->txtDivisaInicial->Location = System::Drawing::Point(277, 30);
			this->txtDivisaInicial->Name = L"txtDivisaInicial";
			this->txtDivisaInicial->Size = System::Drawing::Size(100, 22);
			this->txtDivisaInicial->TabIndex = 5;
			// 
			// txtDivisaFinal
			// 
			this->txtDivisaFinal->Location = System::Drawing::Point(277, 84);
			this->txtDivisaFinal->Name = L"txtDivisaFinal";
			this->txtDivisaFinal->Size = System::Drawing::Size(100, 22);
			this->txtDivisaFinal->TabIndex = 6;
			// 
			// txtImportSelecionat
			// 
			this->txtImportSelecionat->Location = System::Drawing::Point(277, 141);
			this->txtImportSelecionat->Name = L"txtImportSelecionat";
			this->txtImportSelecionat->Size = System::Drawing::Size(100, 22);
			this->txtImportSelecionat->TabIndex = 7;
			// 
			// txtcambi
			// 
			this->txtcambi->Location = System::Drawing::Point(277, 199);
			this->txtcambi->Name = L"txtcambi";
			this->txtcambi->Size = System::Drawing::Size(100, 22);
			this->txtcambi->TabIndex = 8;
			// 
			// txtImportCalculat
			// 
			this->txtImportCalculat->Location = System::Drawing::Point(277, 251);
			this->txtImportCalculat->Name = L"txtImportCalculat";
			this->txtImportCalculat->Size = System::Drawing::Size(100, 22);
			this->txtImportCalculat->TabIndex = 9;
			// 
			// btnNovaConsulta
			// 
			this->btnNovaConsulta->Font = (gcnew System::Drawing::Font(L"Segoe UI", 9));
			this->btnNovaConsulta->Location = System::Drawing::Point(35, 306);
			this->btnNovaConsulta->Name = L"btnNovaConsulta";
			this->btnNovaConsulta->Size = System::Drawing::Size(119, 71);
			this->btnNovaConsulta->TabIndex = 10;
			this->btnNovaConsulta->Text = L"Fer una nova consulta";
			this->btnNovaConsulta->UseVisualStyleBackColor = true;
			this->btnNovaConsulta->Click += gcnew System::EventHandler(this, &MyForm::btnNovaConsulta_Click);
			// 
			// btnGuardarValors
			// 
			this->btnGuardarValors->Font = (gcnew System::Drawing::Font(L"Segoe UI", 9));
			this->btnGuardarValors->Location = System::Drawing::Point(267, 306);
			this->btnGuardarValors->Name = L"btnGuardarValors";
			this->btnGuardarValors->Size = System::Drawing::Size(110, 71);
			this->btnGuardarValors->TabIndex = 11;
			this->btnGuardarValors->Text = L"Guardar els valors";
			this->btnGuardarValors->UseVisualStyleBackColor = true;
			this->btnGuardarValors->Click += gcnew System::EventHandler(this, &MyForm::btnGuardarValors_Click);
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(417, 405);
			this->Controls->Add(this->btnGuardarValors);
			this->Controls->Add(this->btnNovaConsulta);
			this->Controls->Add(this->txtImportCalculat);
			this->Controls->Add(this->txtcambi);
			this->Controls->Add(this->txtImportSelecionat);
			this->Controls->Add(this->txtDivisaFinal);
			this->Controls->Add(this->txtDivisaInicial);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Name = L"MyForm";
			this->Text = L"Canvi de divises";
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void label5_Click(System::Object^ sender, System::EventArgs^ e) {
	}
	public: void cambiarTxt(string DivisaInicial, string DivisaFinal, string ImportSeleccionat, string Cambi, string Resultat)
	{
	//Hem de cambiar de std::string a System::string^. Per això creem un nou System::String creant un punter de la string que teniem
	txtDivisaInicial->Text = gcnew System::String(DivisaInicial.c_str());
	txtDivisaFinal->Text = gcnew System::String(DivisaFinal.c_str());
	txtcambi->Text = gcnew System::String(Cambi.c_str());
	txtImportSelecionat->Text = gcnew System::String(ImportSeleccionat.c_str());
	txtImportCalculat->Text = gcnew System::String(Resultat.c_str());
	}
private: System::Void btnNovaConsulta_Click(System::Object^ sender, System::EventArgs^ e) 
{
	this->Close();
}
private: System::Void btnGuardarValors_Click(System::Object^ sender, System::EventArgs^ e) 
{
	using namespace std;
	Bitmap^ bitmap = gcnew Bitmap(this->Width, this->Height); //classe ref
	Rectangle rectangle(0, 0, bitmap->Width, bitmap->Height); //classe value
	this->DrawToBitmap(bitmap, rectangle);
	SaveFileDialog^ saveFileDialog = gcnew SaveFileDialog();
	saveFileDialog->Filter = "Imatge PNG (*.png)|*.png|Imatge JPEG (*.jpg)|*.jpg";
	saveFileDialog->Title = "Guardar Captura de Pantalla";
	saveFileDialog->FileName = "captura_finestra";
	if (saveFileDialog->ShowDialog() == System::Windows::Forms::DialogResult::OK) //Si s'ha obert de manera correcta
	{
		try
		{
			// Extreure l'extensió seleccionada
			String^ extensio = System::IO::Path::GetExtension(saveFileDialog->FileName)->ToLower();

			// Determinar el format de la imatge segons l'extensió
			System::Drawing::Imaging::ImageFormat^ format = System::Drawing::Imaging::ImageFormat::Png;
			if (extensio == ".jpg") format = System::Drawing::Imaging::ImageFormat::Jpeg;

			// Guardar la imatge al camí seleccionat amb el format corresponent
			bitmap->Save(saveFileDialog->FileName, format);

			MessageBox::Show("La captura de pantalla s'ha guardat correctament.", "Imatge Guardada", MessageBoxButtons::OK, MessageBoxIcon::Information);
		}
		catch (Exception^ ex)
		{
			MessageBox::Show("S'ha produït un error al guardar la imatge:" + ex->Message, "Error", MessageBoxButtons::OK, MessageBoxIcon::Error);
		}
	}
}
private: System::Void MyForm_Load(System::Object^ sender, System::EventArgs^ e) {
}
};
}
