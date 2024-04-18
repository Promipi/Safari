import Breadcrumb from "@/components/Common/Breadcrumb";
import Contact from "@/components/Contact";

import { Metadata } from "next";

export const metadata: Metadata = {
  title: "Contact Page | Free Next.js Template for Startup and SaaS",
  description: "This is Contact Page for Startup Nextjs Template",
  // other metadata
};

const ContactPage = () => {
  return (
    <>
      <Breadcrumb
        pageName="Contactos"
        description="Si tienes alguna pregunta, comentario o simplemente quieres saludar, no dudes en contactarnos."
      />

      <Contact />
    </>
  );
};

export default ContactPage;
