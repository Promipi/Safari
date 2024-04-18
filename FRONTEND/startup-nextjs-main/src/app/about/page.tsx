import AboutSectionOne from "@/components/About/AboutSectionOne";
import AboutSectionTwo from "@/components/About/AboutSectionTwo";
import Breadcrumb from "@/components/Common/Breadcrumb";

import { Metadata } from "next";

export const metadata: Metadata = {
  title: "About Page | Free Next.js Template for Startup and SaaS",
  description: "This is About Page for Startup Nextjs Template",
  // other metadata 
};

const AboutPage = () => {
  return (
    <>
      <Breadcrumb
        pageName="About Us"
        description="Eco Fauna ofrece recorridos guiados por expertos locales en parques nacionales y reservas naturales. Utilizamos tecnología como aplicaciones móviles y realidad aumentada para mejorar la experiencia de cada persona. Además, fomentando el turismo  apoyamos a las comunicades locales e impulsamos su crecimiento econocmico. Únete a nosotros para descubrir la belleza de Paraguay de manera responsable."
      />
      <AboutSectionOne />
      <AboutSectionTwo />
    </>
  );
};

export default AboutPage;
