"use client"
import { signIn, signOut, useSession } from 'next-auth/react'

const ExamplePage = () => {
    const { data: session } = useSession()

    if (session) {
        return (
            <section
                className='
                    mt-40'
            >
                {session?.user?.name} <br />
                <button
                    className='
                        bg-orange-400
                        h-11
                        px-12
                        !cursor-pointer'
                    onClick={() => signOut()}>
                    Sign Out
                </button>
            </section>
        )
    }
    
    return (
        <section
            className='
                mt-40'
        >
            Not signed in <br />
            <button
                className='
                    bg-orange-400
                    h-11
                    px-12
                    !cursor-pointer'
                onClick={() => signIn()}>
                Sign in
            </button>
        </section>
    );
}

export default ExamplePage;