
using CRUD_Forms.Model;
using NITGEN.SDK.NBioBSP;
using System;
using System.Windows.Forms;

namespace CRUD_Forms.Entity
{
    public class Biometria
    {


        NBioAPI m_NBioAPI = new NBioAPI();
        NBioAPI.Type.HFIR hNewFIR;
        NBioAPI.Type.FIR_TEXTENCODE m_textFIR;       
        NBioAPI.IndexSearch m_IndexSearch;
        NBioAPI.Type.WINDOW_OPTION m_WinOption;
        NBioAPI.Type.HFIR hCapturedFIR;
        NBioAPI.Type.FIR_PAYLOAD myPayload;

        public void Form1_Load(object sender, System.EventArgs e)
        {
            uint ret = m_IndexSearch.InitEngine();
            if (ret != NBioAPI.Error.NONE)
            {
            }


            NBioAPI.Type.VERSION version = new NBioAPI.Type.VERSION();
            m_NBioAPI.GetVersion(out version);

        }

        

        public string Registrar()
        {

            NBioAPI.Type.HFIR hEnrolledFIR;

            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            uint ret = m_NBioAPI.Enroll(null, out hEnrolledFIR, null, NBioAPI.Type.TIMEOUT.DEFAULT, null, m_WinOption);

            if (ret != NBioAPI.Error.NONE)
            {
                
                m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
                return "error";
            }

            m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            m_NBioAPI.GetTextFIRFromHandle(hEnrolledFIR, out m_textFIR, true);

           return m_textFIR.TextFIR.ToString();      
        }

        public Boolean Comparar(string Digital)
        {
            uint ret;
            bool result;

            NBioAPI m_NBioAPI = new NBioAPI();
            NBioAPI.Type.HFIR hCapturedFIR = new NBioAPI.Type.HFIR();
            NBioAPI.Type.FIR_TEXTENCODE m_textFIR = new NBioAPI.Type.FIR_TEXTENCODE();
            NBioAPI.Type.FIR_PAYLOAD myPayload = new NBioAPI.Type.FIR_PAYLOAD();

            m_textFIR.TextFIR = Digital;

            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            m_NBioAPI.Capture(out hCapturedFIR);



            ret = m_NBioAPI.VerifyMatch(hCapturedFIR, m_textFIR, out result, myPayload);
           
            return result;
        }
    }
}
