"use client"

import { useSession } from "next-auth/react";
import Image from "next/image";

interface CardProps {
    imageURL?: string;
    title: string;
    description: string;
}

export function Card({
    imageURL,
    description,
    title
}: CardProps) {
    // const { data: {
    //     user
    // } } = useSession()

    // const userId = user.id as any

    return (
        <div
            className="
                border-[1px]
                border-gray-100
                shadow-sm
                overflow-hidden
                rounded-md"
        >
            <div
                className="
                    relative
                    w-full
                    h-52
                    rounded-sm"
            >
                {imageURL ? (
                    <Image
                        src={imageURL}
                        alt="Imagen de Evento"
                        fill
                        className="
                            absolute"
                    />
                ) : <div className="w-full h-full bg-gray-400" />}
            </div>
            <div
                className="
                    p-8"
            >
                <div
                    className="
                        flex
                        flex-col
                        items-center
                        gap-4
                        mb-4"
                >
                    <h1
                        className="
                            font-bold
                            text-2xl
                            text-zinc-700"
                    >
                        {title}
                    </h1>
                </div>
                <p
                    className="
                        text-gray-500
                        text-center"
                >
                    {description}
                </p>
                <button
                    className="
                        mt-12
                        w-full
                        h-14
                        rounded-md
                        bg-primary
                        px-8
                        py-3
                        text-base
                        font-medium
                        text-white"
                    onClick={() => {

                    }}
                >
                    Registrarse
                </button>
            </div>
        </div>
    )
}