#pragma once
#include <string>

namespace CppCLRWinFormsProject {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace std;

	/// <summary>
	/// Summary for Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::TextBox^ txtNum1;
	private: System::Windows::Forms::ComboBox^ ComboBox;
	protected:


	private: System::Windows::Forms::TextBox^ txtNum2;
	private: System::Windows::Forms::Button^ btnOperacio;



	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->txtNum1 = (gcnew System::Windows::Forms::TextBox());
			this->ComboBox = (gcnew System::Windows::Forms::ComboBox());
			this->txtNum2 = (gcnew System::Windows::Forms::TextBox());
			this->btnOperacio = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10.2F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label1->Location = System::Drawing::Point(28, 30);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(265, 20);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Introdueix la operació que vols fer:";
			// 
			// txtNum1
			// 
			this->txtNum1->Location = System::Drawing::Point(32, 126);
			this->txtNum1->Name = L"txtNum1";
			this->txtNum1->Size = System::Drawing::Size(100, 22);
			this->txtNum1->TabIndex = 1;
			// 
			// ComboBox
			// 
			this->ComboBox->FormattingEnabled = true;
			this->ComboBox->Items->AddRange(gcnew cli::array< System::Object^  >(2) { L"+", L"-" });
			this->ComboBox->Location = System::Drawing::Point(157, 126);
			this->ComboBox->Name = L"ComboBox";
			this->ComboBox->Size = System::Drawing::Size(42, 24);
			this->ComboBox->TabIndex = 2;
			// 
			// txtNum2
			// 
			this->txtNum2->Location = System::Drawing::Point(219, 126);
			this->txtNum2->Name = L"txtNum2";
			this->txtNum2->Size = System::Drawing::Size(100, 22);
			this->txtNum2->TabIndex = 3;
			// 
			// btnOperacio
			// 
			this->btnOperacio->Location = System::Drawing::Point(122, 201);
			this->btnOperacio->Name = L"btnOperacio";
			this->btnOperacio->Size = System::Drawing::Size(111, 23);
			this->btnOperacio->TabIndex = 4;
			this->btnOperacio->Text = L"Fer operació";
			this->btnOperacio->UseVisualStyleBackColor = true;
			this->btnOperacio->Click += gcnew System::EventHandler(this, &Form1::btnOperacio_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(346, 246);
			this->Controls->Add(this->btnOperacio);
			this->Controls->Add(this->txtNum2);
			this->Controls->Add(this->ComboBox);
			this->Controls->Add(this->txtNum1);
			this->Controls->Add(this->label1);
			this->Name = L"Form1";
			this->Text = L"Suma/Resta";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void Form1_Load(System::Object^ sender, System::EventArgs^ e) {
	}
		   // Mètode que s'executa quan l'usuari fa clic al botó per realitzar una operació aritmètica (suma o resta)
	private: System::Void btnOperacio_Click(System::Object^ sender, System::EventArgs^ e)
	{
		// Es recuperen les cadenes introduïdes als TextBox i es converteixen a std::string
		string num1 = this->toStandardString(txtNum1->Text);
		string num2 = this->toStandardString(txtNum2->Text);

		try
		{
			// Conversió de les cadenes a enters usant la funció stoi de C++
			int n1 = stoi(num1);
			int n2 = stoi(num2);

			// S’utilitza un switch per identificar quina operació s’ha seleccionat al ComboBox
			switch (ComboBox->SelectedIndex)
			{
			case 0: // Cas de la suma
				MessageBox::Show("La suma de " + n1 + " + " + n2 + " = " + (n1 + n2));
				break;

			case 1: // Cas de la resta
				MessageBox::Show("La resta de " + n1 + " - " + n2 + " = " + (n1 - n2));
				break;

			default: // Si no s’ha seleccionat cap opció vàlida
				MessageBox::Show("Selecciona una operació");
				break;
			}
		}
		catch (Exception^ ex)
		{
			// Captura i mostra qualsevol excepció (com errors de conversió)
			MessageBox::Show("Error: " + ex->Message);
		}

		// Es netegen els camps després de l’operació
		Clean();
	}

	private: static string toStandardString(System::String^ string)
	{
		using System::Runtime::InteropServices::Marshal;
		System::IntPtr pointer = Marshal::StringToHGlobalAnsi(string);
		char* charPointer = reinterpret_cast<char*>(pointer.ToPointer());
		std::string returnString(charPointer, string->Length);
		Marshal::FreeHGlobal(pointer);
		return returnString;
	}
	public: void Clean()
	{
		txtNum1->Text = "";
		txtNum2->Text = "";
	}
};
}
