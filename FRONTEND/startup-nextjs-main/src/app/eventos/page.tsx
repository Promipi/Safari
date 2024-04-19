import Breadcrumb from "@/components/Common/Breadcrumb";
import Events from "@/components/events/Events";

export default function Eventos() {
    return (
        <>
            <Breadcrumb
                pageName="Eventos"
                description="Listado de Eventos Disponibles"
            />
            <Events />
        </>
    )
}