#include <string>
#include <stdexcept>
#include "Form2.h"
#pragma once

namespace CppCLRWinFormsProject {

	double cambi_dolar = 0;
	double cambi_lliura = 0;
	double cambi_euro = 0;

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace std;
	using namespace TFG__1_C__;//

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
	private: System::Windows::Forms::TextBox^ txtValor;

	private: System::Windows::Forms::ComboBox^ comboBox1;
	private: System::Windows::Forms::Button^ btnEuro;
	private: System::Windows::Forms::Button^ btnDolar;
	private: System::Windows::Forms::Button^ btnLliura;
	protected:

	protected:

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container^ components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->txtValor = (gcnew System::Windows::Forms::TextBox());
			this->comboBox1 = (gcnew System::Windows::Forms::ComboBox());
			this->btnEuro = (gcnew System::Windows::Forms::Button());
			this->btnDolar = (gcnew System::Windows::Forms::Button());
			this->btnLliura = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10.2F));
			this->label1->Location = System::Drawing::Point(47, 64);
			this->label1->Margin = System::Windows::Forms::Padding(4, 0, 4, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(247, 20);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Introdueix la moneda a cambiar:";
			// 
			// txtValor
			// 
			this->txtValor->Location = System::Drawing::Point(152, 144);
			this->txtValor->Margin = System::Windows::Forms::Padding(4);
			this->txtValor->Name = L"txtValor";
			this->txtValor->Size = System::Drawing::Size(159, 22);
			this->txtValor->TabIndex = 1;
			// 
			// comboBox1
			// 
			this->comboBox1->FormattingEnabled = true;
			this->comboBox1->Items->AddRange(gcnew cli::array< System::Object^  >(3) { L"€", L"$", L"£" });
			this->comboBox1->Location = System::Drawing::Point(341, 143);
			this->comboBox1->Margin = System::Windows::Forms::Padding(4);
			this->comboBox1->Name = L"comboBox1";
			this->comboBox1->Size = System::Drawing::Size(61, 24);
			this->comboBox1->TabIndex = 2;
			// 
			// btnEuro
			// 
			this->btnEuro->Location = System::Drawing::Point(52, 263);
			this->btnEuro->Margin = System::Windows::Forms::Padding(4);
			this->btnEuro->Name = L"btnEuro";
			this->btnEuro->Size = System::Drawing::Size(100, 28);
			this->btnEuro->TabIndex = 3;
			this->btnEuro->Text = L"Euro(€)";
			this->btnEuro->UseVisualStyleBackColor = true;
			this->btnEuro->Click += gcnew System::EventHandler(this, &Form1::btnEuro_Click);
			// 
			// btnDolar
			// 
			this->btnDolar->Location = System::Drawing::Point(212, 263);
			this->btnDolar->Margin = System::Windows::Forms::Padding(4);
			this->btnDolar->Name = L"btnDolar";
			this->btnDolar->Size = System::Drawing::Size(100, 28);
			this->btnDolar->TabIndex = 4;
			this->btnDolar->Text = L"Dolar($)";
			this->btnDolar->UseVisualStyleBackColor = true;
			this->btnDolar->Click += gcnew System::EventHandler(this, &Form1::btnDolar_Click);
			// 
			// btnLliura
			// 
			this->btnLliura->Location = System::Drawing::Point(367, 263);
			this->btnLliura->Margin = System::Windows::Forms::Padding(4);
			this->btnLliura->Name = L"btnLliura";
			this->btnLliura->Size = System::Drawing::Size(100, 28);
			this->btnLliura->TabIndex = 5;
			this->btnLliura->Text = L"Lliura(£)";
			this->btnLliura->UseVisualStyleBackColor = true;
			this->btnLliura->Click += gcnew System::EventHandler(this, &Form1::btnLliura_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(529, 314);
			this->Controls->Add(this->btnLliura);
			this->Controls->Add(this->btnDolar);
			this->Controls->Add(this->btnEuro);
			this->Controls->Add(this->comboBox1);
			this->Controls->Add(this->txtValor);
			this->Controls->Add(this->label1);
			this->Margin = System::Windows::Forms::Padding(4);
			this->Name = L"Form1";
			this->Text = L"Canvi de divises";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
        // Mètode que s'executa quan es fa clic al botó "Convertir a Euros (€)"
private: System::Void btnEuro_Click(System::Object^ sender, System::EventArgs^ e)
{
    // Converteix el valor introduït en el TextBox a std::string
    string cadena = this->toStandardString(txtValor->Text);

    // Variables per definir les cadenes associades a la conversió
    string divisa_inicial = "";
    string divisa_final = "";
    string import_seleccionat = "";
    string cambi = "";
    string resultat = "";

    // Crea una instància del formulari secundari per mostrar els resultats
    MyForm^ formSecundari = gcnew MyForm();

    // Declara la variable per guardar el valor convertit
    float valor = 0;

    // Intenta convertir la cadena a float
    try
    {
        valor = std::stof(cadena);
    }
    // Si hi ha una excepció, es mostra un missatge i es neteja el formulari
    catch (System::Exception^ e)
    {
        MessageBox::Show("Error: " + e->Message);
        Netejar();
        return;
    }

    // Selecciona la divisa d'origen segons el valor seleccionat al comboBox
    switch (comboBox1->SelectedIndex)
    {
    case 0: // Conversió de € a €
        divisa_inicial = "€";
        divisa_final = "€";
        import_seleccionat = std::to_string(valor);
        import_seleccionat = import_seleccionat.substr(0, import_seleccionat.find(".") + 3);
        cambi = "1.00";
        resultat = std::to_string(valor);
        resultat = resultat.substr(0, resultat.find(".") + 3);
        formSecundari->Show();
        formSecundari->cambiarTxt(divisa_inicial, divisa_final, import_seleccionat + divisa_inicial, cambi, resultat + divisa_final);
        break;

    case 1: // Conversió de $ a €
        cambi_dolar = valor / 1.05;
        divisa_inicial = "$";
        divisa_final = "€";
        import_seleccionat = std::to_string(valor);
        import_seleccionat = import_seleccionat.substr(0, import_seleccionat.find(".") + 3);
        cambi = "0.95";
        resultat = std::to_string(cambi_dolar);
        resultat = resultat.substr(0, resultat.find(".") + 3);
        formSecundari->Show();
        formSecundari->cambiarTxt(divisa_inicial, divisa_final, import_seleccionat + divisa_inicial, cambi, resultat + divisa_final);
        break;

    case 2: // Conversió de £ a €
        cambi_lliura = valor * 1.21;
        divisa_inicial = "£";
        divisa_final = "€";
        import_seleccionat = std::to_string(valor);
        import_seleccionat = import_seleccionat.substr(0, import_seleccionat.find(".") + 3);
        cambi = "1.21";
        resultat = std::to_string(cambi_lliura);
        resultat = resultat.substr(0, resultat.find(".") + 3);
        formSecundari->Show();
        formSecundari->cambiarTxt(divisa_inicial, divisa_final, import_seleccionat + divisa_inicial, cambi, resultat + divisa_final);
        break;

    default: // Cap divisa seleccionada
        MessageBox::Show("Selecciona una divisa disponible");
        break;
    }

    // Neteja el camp de text
    Netejar();
}

       // Mètode que s'executa quan es fa clic al botó "Convertir a Dòlars ($)"
private: System::Void btnDolar_Click(System::Object^ sender, System::EventArgs^ e)
{
    string cadena = this->toStandardString(txtValor->Text);
    string divisa_inicial = "";
    string divisa_final = "";
    string import_seleccionat = "";
    string cambi = "";
    string resultat = "";
    MyForm^ formSecundari = gcnew MyForm();
    float valor = 0;

    try
    {
        valor = std::stof(cadena);
    }
    catch (System::Exception^ e)
    {
        MessageBox::Show("Error: " + e->Message);
        Netejar();
        return;
    }

    switch (comboBox1->SelectedIndex)
    {
    case 0: // € a $
        cambi_dolar = (double)(valor * 1.05);
        divisa_inicial = "€";
        divisa_final = "$";
        import_seleccionat = std::to_string(valor).substr(0, std::to_string(valor).find(".") + 3);
        cambi = "1.05";
        resultat = std::to_string(cambi_dolar).substr(0, std::to_string(cambi_dolar).find(".") + 3);
        formSecundari->Show();
        formSecundari->cambiarTxt(divisa_inicial, divisa_final, import_seleccionat + divisa_inicial, cambi, resultat + divisa_final);
        break;

    case 1: // $ a $
        divisa_inicial = "$";
        divisa_final = "$";
        import_seleccionat = std::to_string(valor).substr(0, std::to_string(valor).find(".") + 3);
        cambi = "1.00";
        resultat = std::to_string(valor).substr(0, std::to_string(valor).find(".") + 3);
        formSecundari->Show();
        formSecundari->cambiarTxt(divisa_inicial, divisa_final, import_seleccionat + divisa_inicial, cambi, resultat + divisa_final);
        break;

    case 2: // £ a $
        cambi_lliura = (double)(valor / 0.79);
        divisa_inicial = "£";
        divisa_final = "$";
        import_seleccionat = std::to_string(valor).substr(0, std::to_string(valor).find(".") + 3);
        cambi = "1.27";
        resultat = std::to_string(cambi_lliura).substr(0, std::to_string(cambi_lliura).find(".") + 3);
        formSecundari->Show();
        formSecundari->cambiarTxt(divisa_inicial, divisa_final, import_seleccionat + divisa_inicial, cambi, resultat + divisa_final);
        break;

    default:
        MessageBox::Show("Selecciona una divisa disponible");
        break;
    }

    Netejar();
}

       // Mètode que s'executa quan es fa clic al botó "Convertir a Lliures (£)"
private: System::Void btnLliura_Click(System::Object^ sender, System::EventArgs^ e)
{
    string cadena = this->toStandardString(txtValor->Text);
    string divisa_inicial = "";
    string divisa_final = "";
    string import_seleccionat = "";
    string cambi = "";
    string resultat = "";
    MyForm^ formSecundari = gcnew MyForm();
    float valor = 0;

    try
    {
        valor = std::stof(cadena);
    }
    catch (System::Exception^ e)
    {
        MessageBox::Show("Error: " + e->Message);
        Netejar();
        return;
    }

    switch (comboBox1->SelectedIndex)
    {
    case 0: // € a £
        cambi_euro = (double)(valor / 1.21);
        divisa_inicial = "€";
        divisa_final = "£";
        import_seleccionat = std::to_string(valor).substr(0, std::to_string(valor).find(".") + 3);
        cambi = "0.83";
        resultat = std::to_string(cambi_euro).substr(0, std::to_string(cambi_euro).find(".") + 3);
        formSecundari->Show();
        formSecundari->cambiarTxt(divisa_inicial, divisa_final, import_seleccionat + divisa_inicial, cambi, resultat + divisa_final);
        break;

    case 1: // $ a £
        cambi_dolar = (double)(valor * 0.79);
        divisa_inicial = "$";
        divisa_final = "£";
        import_seleccionat = std::to_string(valor).substr(0, std::to_string(valor).find(".") + 3);
        cambi = "0.79";
        resultat = std::to_string(cambi_dolar).substr(0, std::to_string(cambi_dolar).find(".") + 3);
        formSecundari->Show();
        formSecundari->cambiarTxt(divisa_inicial, divisa_final, import_seleccionat + divisa_inicial, cambi, resultat + divisa_final);
        break;

    case 2: // £ a £
        divisa_inicial = "£";
        divisa_final = "£";
        import_seleccionat = std::to_string(valor).substr(0, std::to_string(valor).find(".") + 3);
        cambi = "1.00";
        resultat = std::to_string(valor).substr(0, std::to_string(valor).find(".") + 3);
        formSecundari->Show();
        formSecundari->cambiarTxt(divisa_inicial, divisa_final, import_seleccionat + divisa_inicial, cambi, resultat + divisa_final);
        break;

    default:
        MessageBox::Show("Selecciona una divisa disponible");
        break;
    }

    Netejar();
}

       // Mètode auxiliar que neteja el TextBox del valor introduït per l'usuari
       void Netejar()
       {
           txtValor->Text = "";
       }

       // Funció que converteix una cadena de .NET (System::String^) a una cadena de C++ (std::string)
private: static string toStandardString(System::String^ string)
{
    using System::Runtime::InteropServices::Marshal;
    System::IntPtr pointer = Marshal::StringToHGlobalAnsi(string);
    char* charPointer = reinterpret_cast<char*>(pointer.ToPointer());
    std::string returnString(charPointer, string->Length);
    Marshal::FreeHGlobal(pointer);
    return returnString;
}

#pragma endregion 
private: System::Void Form1_Load(System::Object^ sender, System::EventArgs^ e) {
}
};
}
