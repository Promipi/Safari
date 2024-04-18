import Link from "next/link";

const Hero = () => {
  return (
    <>
      <section
        id="home"
        className="relative z-10 overflow-hidden bg-white dark:bg-gray-dark bg-[url(https://grupovierci.brightspotcdn.com/dims4/default/4cc0a28/2147483647/strip/true/crop/4265x2401+0+221/resize/1000x563!/format/webp/quality/90/?url=https%3A%2F%2Fk2-prod-grupo-vierci.s3.us-east-1.amazonaws.com%2Fbrightspot%2Fadjuntos%2F161%2Fimagenes%2F000%2F200%2F0000200480.jpg)] bg-no-repeat bg-[center_center] bg-cover"
      >
        <div className="h-screen backdrop-blur">
          <div className="container h-screen">
            <div className="mx-4 flex flex-wrap">
              <div className="w-200
                              h-200
                              bg-cover">
                <div className="mx-auto text-center h-screen flex flex-col justify-center ">
                  
                  <h1 className="mb-5 text-3xl font-bold leading-tight text-black dark:text-white sm:text-4xl sm:leading-tight md:text-5xl md:leading-tight">
                    ECO FAUNA
                  </h1>
                  <p className="mb-12 text-base !leading-relaxed text-body-color dark:text-body-color-dark sm:text-lg md:text-xl">
                    Ofrecemos oportunidades emocionantes para explorar la naturaleza y la cultura local de manera sostenible y asequible.
                  </p>

                  </div>
                </div>
              </div>
          </div>
        </div>

      </section>
    </>
  );
};

export default Hero;
