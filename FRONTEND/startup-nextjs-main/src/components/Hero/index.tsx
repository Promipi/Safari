import Link from "next/link";

const Hero = () => {
  return (
    <>
      <section
        id="home"
        className="
          relative
          z-10
          overflow-hidden
          min-h-[85vh]
          bg-gray-100
          bg-[url(/images/hero/pantanal2.jpg)]
          bg-no-repeat
          bg-[center_top]
          bg-cover
          pb-16
          pt-[120px]
          md:pb-[120px]
          md:pt-[150px]
          xl:pb-[160px]
          xl:pt-[180px]
          2xl:pb-[200px]
          2xl:pt-[210px]
          bg-blend-light
          bg-fixed"
      >
        <div
          className="
            container
            absolute
            top-1/2
            -translate-y-1/2
            left-1/2
            -translate-x-1/2"
        >
          <div className="-mx-4 flex flex-wrap">
            <div className="w-full px-4">
              <div className="mx-auto max-w-[800px] text-center">
                <h1
                  className="
                    mb-5
                    text-3xl
                    font-bold
                    leading-tight
                    text-white
                    sm:text-4xl
                    sm:leading-tight
                    md:text-5xl
                    md:leading-tight"
                >
                  ECO FAUNA
                </h1>
                <p className="
                  mb-12
                  text-base
                  !leading-relaxed
                  text-yellow-700
                  sm:text-lg
                  md:text-xl
                  text-white"
                >
                  Promovemos la preservación de especies como jaguares y aves exóticas en su hábitat natural. Ofrecemos paseos en auto por áreas naturales, donde puedes disfrutar de la biodiversidad mientras garantizamos el mínimo impacto ambiental. Únete a nosotros para vivir experiencias enriquecedoras y contribuir a la conservación de nuestro planeta.
                </p>
                
                </div>
              </div>
            </div>
          </div>
      </section>
    </>
  );
};

export default Hero;
