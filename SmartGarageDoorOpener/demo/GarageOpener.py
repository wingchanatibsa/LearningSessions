import asyncio
import logging

from aiohttp import ClientSession

from pymyq import login
from pymyq.errors import MyQError, RequestError
from pymyq.garagedoor import STATE_OPEN, STATE_CLOSED

_LOGGER = logging.getLogger()

EMAIL = "YourEmailAddress" #Your MyQ login email
PASSWORD = "YourPassword" #Your MyQ login password

async def main() -> None:
    logging.basicConfig(level=logging.ERROR)
    async with ClientSession() as websession:
        try:
            # Create an API object:
            # print(f"{EMAIL} {PASSWORD}")
            api = await login(EMAIL, PASSWORD, websession)
            for account in api.accounts:
                # print(f"Account ID: {account}")
                # print(f"Account Name: {api.accounts[account]}")

                # Get all devices listed with this account – note that you can use
                # api.covers to only examine covers or api.lamps for only lamps.
                # print(f"  GarageDoors: {len(api.covers)}")
                # print("  ---------------")
                if len(api.covers) != 0:
                    for idx, device_id in enumerate(
                        device_id
                        for device_id in api.covers
                        if api.devices[device_id].account == account
                    ):
                        device = api.devices[device_id]
                        try:
                            if device.open_allowed:
                                if device.state == STATE_OPEN:
                                    print(
                                        f"Garage door {device.name} is already open"
                                    )
                                else:
                                    print(f"Opening garage door {device.name}")
                                    try:
                                        if await device.open(wait_for_state=True):
                                            print(
                                                f"Garage door {device.name} has been opened."
                                            )
                                        else:
                                            print(
                                                f"Failed to open garage door {device.name}."
                                            )
                                    except MyQError as err:
                                        _LOGGER.error(
                                            f"Error when trying to open {device.name}: {str(err)}"
                                        )
                        except RequestError as err:
                            _LOGGER.error(err)
        except MyQError as err:
            _LOGGER.error("There was an error: %s", err)

asyncio.get_event_loop().run_until_complete(main())